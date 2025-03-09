using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace internet_server
{
    public partial class game_windows : Form
    {
        //By HaretaSK
        Random rand = new Random();
        ArrayList wolfList = new ArrayList();
        ArrayList villagerList = new ArrayList();
        //By HaretaSK
        const int wolf_number = 2;
        const int Villager_number = 6;
        int player_number = wolf_number + Villager_number;
        static Socket[] player = new Socket[wolf_number + Villager_number];
        public delegate void changetext(string text);
        public delegate void DAY_NIGHT();
        static TextBox message;
        static bool check = false;
        int already_voting = 0;
        static public Label DAY;
        static public Form form;
        int[] death = new int[wolf_number + Villager_number];

        //change player_number
        public game_windows(Socket[] players, ArrayList IDs)
        {
            InitializeComponent();
            form = this;
            check = false;
            player = players;
            DAY = state;
            message = textBox1;
            //By HaretaSK
            int remainWolf = wolf_number;
            for (int i = 0; i < player_number; i++)
            {
                if (remainWolf > 0 && rand.Next(0, 2) == 1 || remainWolf >= (player_number - i))
                {
                    player[i].Send(Encoding.UTF8.GetBytes("START\\狼人\\" + (i + 1).ToString()));
                    remainWolf--;
                    wolfList.Add(i);
                }
                else
                {
                    player[i].Send(Encoding.UTF8.GetBytes("START\\村民\\" + (i + 1).ToString()));
                    villagerList.Add(i);
                }
                //By HaretaSK
                Thread thread = new Thread(receive_message);
                thread.IsBackground = true;
                thread.Start(i);
            }
        }
        public void send_message(string text)
        {
            int i = 0;
            for (; i < wolf_number + Villager_number; i++)
            {
                try
                {
                    player[i].Send(Encoding.UTF8.GetBytes(text));
                }
                catch
                {

                }
            }
        }
        static public void close_windows()
        {
            form.Close();
        }
        static public void change_message(string text)
        {
            message.Text += text;
            message.Text += "\r\n";
        }
        public void receive_message(Object number)
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[50];
                    player[(int)number].Receive(data);
                    string temp = Encoding.UTF8.GetString(data);
                    if (temp.Split('\\')[0] == "VOTE")
                    {
                        send_message("村民" + (((int)number) + 1) + "投給村民" + Int32.Parse(temp.Split('\\')[1]).ToString() + "一票");
                        death[Int32.Parse(temp.Split('\\')[1]) - 1]++;
                        already_voting++;
                        if ((check && already_voting == wolfList.Count) || already_voting == player_number)
                        {
                            int max_voting = 0, index = 0;
                            for (int y = 0; y < wolf_number + Villager_number; y++)
                            {
                                if (death[y] > max_voting)
                                {
                                    index = y;
                                    max_voting = death[y];
                                }
                            }
                            death = new int[wolf_number + Villager_number];
                            if (wolfList.Contains(index))
                            {
                                Thread.Sleep(1000);
                                send_message("DEATH\\" + (index + 1).ToString());
                                Thread.Sleep(2000);
                                //send_message("死者身分為狼人\r\n");
                                wolfList.Remove(index);
                            }
                            else
                            {
                                Thread.Sleep(1000);
                                send_message("DEATH\\" + (index + 1).ToString());
                                Thread.Sleep(2000);
                                //send_message("死者身分為村民\r\n");
                                villagerList.Remove(index);
                            }
                            player_number--;
                            if (wolfList.Count >= villagerList.Count)
                            {
                                send_message("END\\狼人獲勝");
                                form.Invoke(new DAY_NIGHT(close_windows));
                            }
                            else if (wolfList.Count == 0)
                            {
                                send_message("END\\村民獲勝");
                                form.Invoke(new DAY_NIGHT(close_windows));
                            }
                            else
                            {
                                Thread.Sleep(5000);
                                DAY.Invoke(new DAY_NIGHT(change_DAY));
                                send_message("NIGHT\\");
                                already_voting = 0;
                            }
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        send_message("村民" + ((int)number + 1) + ":" + temp);
                        message.Invoke(new changetext(change_message), "村民" + ((int)number + 1) + ":" + temp + "\r\n");
                    }
                }

                catch
                {
                    break;
                }
            }
        }
        static public void change_DAY()
        {
            if (!check)
            {
                DAY.Text = "晚上";
                check = true;
            }
            else
            {
                DAY.Text = "白天";
                check = false;
            }
        }








        private void game_windows_Load(object sender, EventArgs e)
        {

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
