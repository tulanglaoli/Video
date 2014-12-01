using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace vlc.net
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playinig_;
        private NewSocket S;

        public Form1()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);

            tbVideoTime.Text = "00:00:00/00:00:00";

            is_playinig_ = false;
            S = new NewSocket();
            S.Init("127.0.0.1", 2000);
            timer2.Start();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            {
                //vlc_player_.PlayFile(ofd.FileName);
                vlc_player_.PlayFile("A.avi");
                trackBar1.SetRange(0, (int)vlc_player_.Duration());
                trackBar1.Value = 0;
                timer1.Start();
                is_playinig_ = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                if (trackBar1.Value == trackBar1.Maximum)
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                }
                else
                {
                    trackBar1.Value = trackBar1.Value + 1;
                    tbVideoTime.Text = string.Format("{0}/{1}", 
                        GetTimeString(trackBar1.Value), 
                        GetTimeString(trackBar1.Maximum));
                }
            }
        }

        private string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.SetPlayTime(trackBar1.Value);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }




        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            S.SocketQuit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {


                if (S.ReturnStr().Contains("FF"))
                {
                    vlc_player_.PlayFile("A.avi");
                    trackBar1.SetRange(0, (int)vlc_player_.Duration());
                    trackBar1.Value = 0;
                    timer1.Start();
                    is_playinig_ = true;
                    S.SetStrEmpty();
                }
                else if (S.ReturnStr().Contains("SS"))
                {
                    vlc_player_.Stop();
                    trackBar1.Value = 0;
                    timer1.Stop();
                    is_playinig_ = false;
                    S.SetStrEmpty();
                }
            
            
        }
    }
}
