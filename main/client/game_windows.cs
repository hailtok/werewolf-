using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Media;

namespace client
{
    public partial class game_windows : Form
    {
        const int wolf_number = 2;
        const int Villager_number = 6;
        static int all_player = wolf_number + Villager_number;
        string data;
        Socket server;
        static TextBox text;
        static TextBox all_text;
        static Label now_DAY_NIGHT;
        static Label now_state_ID;
        public delegate void changetext(string text);
        public delegate void DAY_NIGHT();
        static Form back;
        static Button vote;
        static bool check = false;
        static Label survive;
        static ComboBox vote_list;
        static Button send_message;
        static string name;
        static Label player_number;
        static SoundPlayer day_player = new SoundPlayer(Properties.Resources.noonBGM);
        static SoundPlayer night_player = new SoundPlayer(Properties.Resources.nightBGM);
        static SoundPlayer switch_to_night = new SoundPlayer(Properties.Resources.switch_night);
        static SoundPlayer switch_to_day = new SoundPlayer(Properties.Resources.switch_noon);
        static PictureBox Sun;
        static PictureBox Moon;
        public game_windows(Socket socket, Form first)
        {
            InitializeComponent();
            Sun = sun;
            Moon = moon;
            send_message = send;
            server = socket;
            text = message;
            vote_list = comboBox;
            player_number = number;
            survive = label5;
            now_DAY_NIGHT = state;
            vote = voting;
            now_state_ID = label6;
            label5.Text = all_player.ToString();
            label6.Text = "";
            all_text = textBox1;
            back = this;
            textBox1.Focus();
            for (int k = 0; k < all_player; k++)
            {
                comboBox.Items.Add("村民" + (k + 1));
            }
            day_player.PlayLooping();
            Thread thread = new Thread(receive_message);
            thread.IsBackground = true;
            thread.Start();
        }
        private void send_Click(object sender, EventArgs e)
        {
            data = message.Text;
            try
            {
                server.Send(Encoding.UTF8.GetBytes(data));
                message.Clear();
            }
            catch
            {
                MessageBox.Show("傳送訊息失敗");
            }
        }
        public void receive_message()
        {
            while (true)
            {
                try
                {
                    byte[] temp = new byte[100];
                    server.Receive(temp);
                    data = Encoding.UTF8.GetString(temp);
                    if (data.Split('\\')[0] == "START")
                    {
                        while (true)
                        {
                            try
                            {
                                string temp_ID = data.Split('\\')[1];
                                now_state_ID.Invoke(new changetext(show_identity), temp_ID);
                                player_number.Invoke(new changetext(change_number), data.Split('\\')[2]);
                                name = temp_ID;
                                break;
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (data.Split('\\')[0] == "NIGHT")
                    {
                        vote.Invoke(new DAY_NIGHT(change_DAY_NIGHT));
                        survive.Invoke(new DAY_NIGHT(show_player_survive));
                    }
                    else if (data.Split('\\')[0] == "DEATH")
                    {
                        string death_people = data.Split('\\')[1];
                        if (Int16.Parse(player_number.Text) == Int32.Parse(death_people))
                        {
                            Thread.Sleep(5000);
                            server.Send(Encoding.UTF8.GetBytes("已經遭到擊殺"));
                            MessageBox.Show("你輸了，你已遭他人殺害");
                            Application.Exit();
                        }
                        vote_list.Invoke(new changetext(delete_death_player), "村民" + Int32.Parse(death_people));
                    }
                    else if (data.Split('\\')[0] == "END")
                    {
                        MessageBox.Show("遊戲結束，" + data.Split('\\')[1]);
                        Application.Exit();
                    }
                    else
                    {
                        if (!check || name == "狼人")
                        {
                            all_text.Invoke(new changetext(show_message), data);
                        }
                    }
                }
                catch (Exception)
                {
                    server.Close();
                    break;
                }
            }
        }
        static void change_number(string number)
        {
            player_number.Text = number;
        }
        static void delete_death_player(string input)
        {
            vote_list.Items.Remove(input);
        }
        static void change_DAY_NIGHT()
        {
            if (!check && now_state_ID.Text == "狼人")
            {
                send_message.Enabled = true;
                vote.Enabled = true;
            }
            if (check)
            {
                night_player.Stop();
                //switch_to_day.Play();
                Sun.Visible = true;
                Moon.Visible = false;
                back.BackColor = SystemColors.Window;
                now_DAY_NIGHT.Text = "白天";
                vote.Enabled = true;
                send_message.Enabled = true;
                check = false;

                day_player.PlayLooping();
            }
            else
            {
                Sun.Visible = false;
                Moon.Visible = true;
                day_player.Stop();
                //switch_to_night.Play();
                back.BackColor = SystemColors.WindowText;
                now_DAY_NIGHT.Text = "晚上";
                check = true;
                night_player.PlayLooping();
            }
        }
        static void show_identity(string input)
        {
            now_state_ID.Text = input;
        }
        static void show_player_survive()
        {
            all_player--;
            survive.Text = all_player.ToString();
        }
        static void show_message(string input)
        {
            if (!all_text.InvokeRequired)
            {
                all_text.Text += input;
                all_text.Text += "\r\n";
                all_text.SelectionStart = all_text.Text.Length;
                all_text.ScrollToCaret();
            }
        }
        private void game_windows_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("遊戲結束");
            server.Close();
            Application.Exit();
        }
        private void timer_Tick(object sender, EventArgs e)
        {

        }
        private void voting_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.Items.Contains(comboBox.SelectedItem))
                {
                    server.Send(Encoding.UTF8.GetBytes("VOTE\\" + comboBox.Text.Split('民')[1]));
                    comboBox.Text = "";
                    send.Enabled = false;
                    voting.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("請投票給確實存在的人");
            }
        }
    }
}
