using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace internet_server
{
    public partial class Form1 : Form
    {
        const int maxsize = 100;
        const int maxplayer = 3;
        static ArrayList mute_list=new ArrayList();
        static Socket[] socket = new Socket[maxsize];
        static bool[] check = new bool[maxsize];
        static ArrayList used = new ArrayList();
        static ArrayList participate = new ArrayList();
        static Socket[] players = new Socket[maxsize];
        static IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
        static IPAddress address = entry.AddressList[1];
        static int player_number = 1;
        public delegate void changetext(string text);
        public delegate void change_player_number();
        public delegate void change_windows(Form be_show);
        Socket start = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static TextBox box;
        static ComboBox choose;
        static Form form;
        static Label player_online;
        public Form1()
        {
            InitializeComponent();
            start.Bind(new IPEndPoint(IPAddress.Any, 7600));
            start.Listen(50);
            message.Text += "連接客戶端中，請等待...\r\n";
            player_online = label5;
            Thread begin = new Thread(startserver);
            begin.IsBackground = true;
            box = message;
            choose = comboBox1;
            form = this;
            begin.Start();
        }
        public void startserver()
        {
            Thread wait_for_player = new Thread(start_game);
            wait_for_player.IsBackground = true;
            wait_for_player.Start();
            Random random = new Random();
            while (true)
            {
                if (used.Count < maxsize)
                {
                    try
                    {
                        int num = 1, tempport = doublehash(random.Next(), num);
                        while (check[tempport])
                        {
                            num++;
                            tempport = doublehash(tempport, num);
                        }
                        socket[tempport] = start.Accept();
                        try
                        {
                            socket[tempport].Send(Encoding.UTF8.GetBytes("你的ID為:" + address.ToString() + ":" + (tempport + 8000).ToString() + "\r\n"));
                            player_number++;
                            player_online.Invoke(new change_player_number(player_number_change));
                            Thread thread = new Thread(socketwaiting);
                            thread.IsBackground = true;
                            check[tempport] = true;
                            byte[] dat = new byte[50];
                            used.Add(tempport);
                            thread.Start(tempport);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("客戶端連線失敗");
                    }
                }
            }
        }
        public void start_game()
        {
            while (true)
            {
                if (participate.Count >= maxplayer)
                {
                    Socket[] temp_sockets = new Socket[maxplayer];
                    ArrayList temp_list = new ArrayList();
                    for (int k = 0; k < maxplayer; k++)
                    {
                        temp_list.Add(participate[0]);
                        temp_sockets[k] = players[(int)temp_list[k]];
                        choose.Invoke(new changetext(deleteclient), ((int)participate[0] + 8000).ToString());
                        check[(int)participate[0]] = false;
                        participate.Remove(participate[0]);
                        temp_sockets[k].Send(Encoding.UTF8.GetBytes("BEGIN\\"));
                        player_number--;
                    }
                    game_windows game = new game_windows(temp_sockets, temp_list);
                    form.Invoke(new change_windows(show_form), game);
                    player_online.Invoke(new change_player_number(player_number_change));
                }
            }
        }
        static void player_number_change()
        {
            player_online.Text = player_number.ToString();
        }
        static void show_form(Form k)
        {
            k.Show(form);
        }
        public int doublehash(int address, int time)
        {
            if (time == 1)
            {
                return address % maxsize;
            }
            else if (time == 2)
            {
                return (address * 27 + 23) % maxsize;
            }
            else
            {
                return ((time - 2) * address % maxsize + (address * 27 + 23) % maxsize) % maxsize;
            }
        }
        static void deal(string a)
        {
            if (!box.InvokeRequired)
            {
                box.Text += a;
                box.Text += "\r\n";
                box.SelectionStart = box.Text.Length;
                box.ScrollToCaret();
            }
        }
        static void banname(string a)
        {
            if (!choose.InvokeRequired)
            {
                choose.Items.Add(a);
            }
        }
        static void deleteclient(string port)
        {
            if (!choose.InvokeRequired)
            {
                if ((string)choose.SelectedItem == port)
                {
                    choose.Text = "";
                }
                choose.Items.Remove(port);
            }
        }
        static public void socketwaiting(object i)
        {
            IPEndPoint point = new IPEndPoint(address, (int)i + 8000);
            try
            {
                Socket receive = socket[(int)i];
                choose.Invoke(new changetext(banname), point.Port.ToString());
                box.Invoke(new changetext(deal), point.ToString() + "已加入");
                while (true)
                {
                    byte[] data = new byte[50];
                    socket[(int)i].Receive(data);
                    string pass_message = Encoding.UTF8.GetString(data);
                    pass_message = pass_message.Split('\\')[0];
                    if (pass_message == "Start_game")
                    {
                        players[(int)i] = socket[(int)i];
                        participate.Add((int)i);
                        used.Remove((int)i);
                        break;
                    }
                    else if(!mute_list.Contains((int)i+8000))
                    {
                        for (int j = 0; j < used.Count; j++)
                        {
                            try
                            {
                                socket[(int)used[j]].Send(Encoding.UTF8.GetBytes("來自" + point.ToString() + ": " + pass_message));
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        box.Invoke(new changetext(deal), "來自" + point.ToString() + ": " + Encoding.UTF8.GetString(data));
                    }
                }
            }
            catch (Exception)
            {
                player_number--;
                socket[(int)i].Close();
                check[(int)i] = false;
                used.Remove((int)i);
                for (int j = 0; j < used.Count; j++)
                {
                    try
                    {
                        socket[(int)used[j]].Send(Encoding.UTF8.GetBytes(point.ToString() + "已退出聊天\r\n"));
                    }
                    catch
                    {
                        continue;
                    }
                }
                box.Invoke(new changetext(deal), point.ToString() + "已退出");
                choose.Invoke(new changetext(deleteclient), point.Port.ToString());
                player_online.Invoke(new change_player_number(player_number_change));
            }
        }
        private void send_Click(object sender, EventArgs e)
        {
            string temp = text.Text;
            for (int j = 0; j < used.Count; j++)
            {
                try
                {
                    socket[(int)used[j]].Send(Encoding.UTF8.GetBytes("管理員:" + temp));
                }
                catch
                {
                    continue;
                }
            }
            message.Invoke(new changetext(deal), "管理員:" + temp);
            text.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int be_ban = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                socket[be_ban - 8000].Close();
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                comboBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("請輸入正確的數字，或實際存在的port編號");
            }
        }

        private void mute_Click(object sender, EventArgs e)
        {
            try
            {
                int be_ban = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                mute_list.Add(be_ban);
                comboBox1.Text = "";
                for (int j = 0; j < used.Count; j++)
                {
                    try
                    {
                        socket[(int)used[j]].Send(Encoding.UTF8.GetBytes("編號"+ be_ban + "已被管理員禁言\r\n"));
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch
            {
                MessageBox.Show("請輸入正確的數字，或實際存在的port編號");
            }
        }
    }
}
