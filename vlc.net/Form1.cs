using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DotNet.Utilities;

namespace vlc.net
{
    public partial class Form1 : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playinig_;
        private NewSocket S;
        private string IP;
        private int port;
        public Form1()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\vlc\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);

            tbVideoTime.Text = "00:00:00/00:00:00";

            is_playinig_ = false;
            
            timer2.Start();
            
        }

        #region Event
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                if (trackBar1.Value == trackBar1.Maximum)
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                    tbVideoTime.Text = "00:00:00/00:00:00";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            IP = ConfigHelper.GetConfigString("IP");
            port = ConfigHelper.GetConfigInt("Port");
            label_fileselect.Text = ConfigHelper.GetConfigString("file");
            S = new NewSocket();
            S.Init(IP, port);
            ShowIP_label.Text = "IP:" + IP.ToString() + "|Port:" + port;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            S.SocketQuit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (S.ReturnStr().Contains("FF"))
            {
                Play();
                S.SetStrEmpty();
            }
            else if (S.ReturnStr().Contains("SS"))
            {
                Stop();
                S.SetStrEmpty();
            }
            else if (S.ReturnStr().Contains("PP"))
            {
                pause();
                S.SetStrEmpty();
            }
            else if (S.ReturnStr().Contains("RR"))
            {
                Forward();
                S.SetStrEmpty();
            }
            else if (S.ReturnStr().Contains("LL"))
            {
                Back();
                S.SetStrEmpty();
            }
            else if (S.ReturnStr().Contains("CC"))
            {
                Fullscreen();
                S.SetStrEmpty();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void button_fileselect_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void Forward_button_Click(object sender, EventArgs e)
        {
            Forward();
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Fullscreen_button_Click(object sender, EventArgs e)
        {
            Fullscreen();
        }

        private void Pause_button_Click(object sender, EventArgs e)
        {
            pause();
        }
        #endregion Event

     
        //按键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {

                case Keys.Right:

                    Forward();

                    break;

                case Keys.Left:

                    Back();

                    break;

                case Keys.Escape:

                     Fullscreen();

                    break;
                case Keys.Space:

                     pause();

                    break;
            }

            return true;//如果要调用KeyDown,这里一定要返回false才行,否则只响应重写方法里的按键.

            //这里调用一下父类方向,相当于调用普通的KeyDown事件.//所以按空格会弹出两个对话框

            //return base.ProcessCmdKey(ref msg, keyData);

        }


        #region 
        void Fullscreen()
        {
            if (!panel2.Visible)//如果当前的窗体是最大化
            {
                vlc_player_.SetFullScreen(true); 
                this.WindowState = FormWindowState.Normal;//把当前窗体还原默认大小
                panel1.Size = new Size(this.Size.Width, this.Size.Height - panel2.Size.Height);
                panel2.Visible = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            else
            {
                vlc_player_.SetFullScreen(false);
                this.FormBorderStyle = FormBorderStyle.None;//将该窗体的边框设置为无,也就是没有标题栏以及窗口边框的
                //this.WindowState = FormWindowState.Maximized;//将该窗体设置为最大化(方法1，适用于单一屏幕)

                Rectangle rect = new Rectangle();rect = Screen.GetWorkingArea(this);//获取屏幕大小
                this.Width = rect.Width;
                this.Height = rect.Width;
  
                this.Location = new Point(0, 0);
                panel1.Size = this.Size;
                panel2.Visible = false;
            }
        }

        void Back()
        {
            if (is_playinig_)
            {
                vlc_player_.SetPlayTime(vlc_player_.GetPlayTime() - 10);
                if (trackBar1.Value > 10)
                {
                    trackBar1.Value -= 10;
                }
                else
                {
                    trackBar1.Value = 0;
                }
            }
        }

        void Forward()
        {
            if (is_playinig_)
            {
                vlc_player_.SetPlayTime(vlc_player_.GetPlayTime() + 10);
                if (trackBar1.Value > trackBar1.Maximum - 10)
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                    tbVideoTime.Text = "00:00:00/00:00:00";
                }
                else
                {
                    trackBar1.Value += 10;
                }
            }
        }

        void pause()
        {
            if (is_playinig_)
            {
                timer1.Stop();
                vlc_player_.SetPlayTime(vlc_player_.GetPlayTime());
                vlc_player_.Pause();
                is_playinig_ = false;
            }
            else
            {
                timer1.Start();
                vlc_player_.SetPlayTime(vlc_player_.GetPlayTime());
                vlc_player_.Pause();
                is_playinig_ = true;
            }
        }

        void Stop()
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
        }

        void Play()
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            {
                //vlc_player_.PlayFile(ofd.FileName);
                vlc_player_.PlayFile(label_fileselect.Text);
                trackBar1.SetRange(0, (int)vlc_player_.Duration());
                trackBar1.Value = 0;
                timer1.Start();
                is_playinig_ = true;
            }
        }

        void Select()
        {
            string Pdfpath = "";
            OpenFileDialog op = openFileDialog1;
            op.Filter = "avi(*.avi)|*.avi|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Pdfpath = op.FileName;
                label_fileselect.Text = System.IO.Path.GetFullPath(Pdfpath);
                //if (System.IO.File.Exists(label_checkPostion.Text) && System.IO.File.Exists(textBox_Showpath.Text))
            }
            else
            {
                label_fileselect.Text = "";
            }
        }
        #endregion

       

    }
}
