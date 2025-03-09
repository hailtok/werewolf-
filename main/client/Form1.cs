using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Media;

namespace client
{
    public partial class Form1 : Form
    {
        string data;
        static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        static IPAddress address = ipHostInfo.AddressList[1];
        static Socket socket = new Socket(address.AddressFamily,
        SocketType.Stream, ProtocolType.Tcp);
        static TextBox text;
        static Form form;
        public delegate void changetext(string text);
        public delegate void change_windows(Form be_show);
        public delegate void change_button();
        static IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7600);
        static Button send_button;
        static Button join_game_button;
        static SoundPlayer waiting_music = new SoundPlayer(Properties.Resources.waitingBGM);
        public Form1()
        {
            InitializeComponent();
            form = this;
            send_button = send;
            join_game_button = game_join;
            text = textBox1;
            sendmessage.Focus();
            text.Text += ("請等待server連結\r\n");
            Thread a = new Thread(startconnect);
            waiting_music.PlayLooping();
            a.Start();
        }
        static void deal(string a)
        {
            if (!text.InvokeRequired)
            {
                text.Text += a;
                text.Text += "\r\n";
                text.SelectionStart = text.Text.Length;
                text.ScrollToCaret();
            }
        }
        static void startconnect()
        {
            try
            {
                Thread thread = new Thread(receive);
                thread.IsBackground = true;
                socket.Connect(point);
                thread.Start(socket);
            }
            catch (Exception)
            {
                socket.Close();
                MessageBox.Show("連線失敗");
                Application.Exit();
            }
        }
        static void show_online_text()
        {
            text.Text += "已連線可以開始輸入文字\r\n";
        }
        static void change_enable()
        {
            send_button.Enabled = true;
            join_game_button.Enabled = true;
        }
        static void getinformation()
        {
            try
            {
                byte[] sentence = new byte[100];
                ((Socket)socket).Receive(sentence);
                text.Text += Encoding.UTF8.GetString(sentence);
            }
            catch
            {

            }
        }
        static void receive(Object socket)
        {
            getinformation();
            join_game_button.Invoke(new change_button(change_enable));
            text.Invoke(new change_button(show_online_text));
            while (true)
            {
                try
                {
                    byte[] sentence = new byte[100];
                    ((Socket)socket).Receive(sentence);
                    string a = Encoding.UTF8.GetString(sentence);
                    if (a.Split('\\')[0] == "BEGIN")
                    {
                        waiting_music.Stop();
                        game_windows game = new game_windows((Socket)socket, form);
                        form.Invoke(new change_windows(show_form), game);
                        break;
                    }
                    else
                    {
                        text.Invoke(new changetext(deal), a);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("你已被管理員踢出");
                    Application.Exit();
                    break;
                }
            }
        }
        static public void show_form(Form k)
        {
            form.Visible = false;
            k.Show(form);
        }
        private void send_Click(object sender, EventArgs e)
        {
            data = sendmessage.Text;
            sendmessage.Text = "";
            sendmessage.Focus();
            socket.Send(Encoding.UTF8.GetBytes(data));
        }
        private void game_join_Click(object sender, EventArgs e)
        {
            send.Enabled = false;
            game_join.Enabled = false;
            socket.Send(Encoding.UTF8.GetBytes("Start_game\\"));
            textBox1.Text += "請等待其他玩家\r\n";
        }
    }
}



