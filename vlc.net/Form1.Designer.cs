namespace vlc.net
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShowIP_label = new System.Windows.Forms.Label();
            this.Pause_button = new System.Windows.Forms.Button();
            this.Fullscreen_button = new System.Windows.Forms.Button();
            this.Back_button = new System.Windows.Forms.Button();
            this.Forward_button = new System.Windows.Forms.Button();
            this.label_fileselect = new System.Windows.Forms.Label();
            this.button_fileselect = new System.Windows.Forms.Button();
            this.tbVideoTime = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 467);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.ShowIP_label);
            this.panel2.Controls.Add(this.Pause_button);
            this.panel2.Controls.Add(this.Fullscreen_button);
            this.panel2.Controls.Add(this.Back_button);
            this.panel2.Controls.Add(this.Forward_button);
            this.panel2.Controls.Add(this.label_fileselect);
            this.panel2.Controls.Add(this.button_fileselect);
            this.panel2.Controls.Add(this.tbVideoTime);
            this.panel2.Controls.Add(this.trackBar2);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Location = new System.Drawing.Point(0, 474);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 111);
            this.panel2.TabIndex = 1;
            // 
            // ShowIP_label
            // 
            this.ShowIP_label.AutoSize = true;
            this.ShowIP_label.Location = new System.Drawing.Point(275, 68);
            this.ShowIP_label.Name = "ShowIP_label";
            this.ShowIP_label.Size = new System.Drawing.Size(23, 12);
            this.ShowIP_label.TabIndex = 13;
            this.ShowIP_label.Text = "...";
            // 
            // Pause_button
            // 
            this.Pause_button.Location = new System.Drawing.Point(209, 62);
            this.Pause_button.Name = "Pause_button";
            this.Pause_button.Size = new System.Drawing.Size(60, 25);
            this.Pause_button.TabIndex = 12;
            this.Pause_button.Text = "暂停";
            this.Pause_button.UseVisualStyleBackColor = true;
            this.Pause_button.Click += new System.EventHandler(this.Pause_button_Click);
            // 
            // Fullscreen_button
            // 
            this.Fullscreen_button.Location = new System.Drawing.Point(133, 62);
            this.Fullscreen_button.Name = "Fullscreen_button";
            this.Fullscreen_button.Size = new System.Drawing.Size(68, 25);
            this.Fullscreen_button.TabIndex = 11;
            this.Fullscreen_button.Text = "全屏";
            this.Fullscreen_button.UseVisualStyleBackColor = true;
            this.Fullscreen_button.Click += new System.EventHandler(this.Fullscreen_button_Click);
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(70, 62);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(57, 25);
            this.Back_button.TabIndex = 10;
            this.Back_button.Text = "后退";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // Forward_button
            // 
            this.Forward_button.Location = new System.Drawing.Point(8, 62);
            this.Forward_button.Name = "Forward_button";
            this.Forward_button.Size = new System.Drawing.Size(56, 25);
            this.Forward_button.TabIndex = 9;
            this.Forward_button.Text = "快进";
            this.Forward_button.UseVisualStyleBackColor = true;
            this.Forward_button.Click += new System.EventHandler(this.Forward_button_Click);
            // 
            // label_fileselect
            // 
            this.label_fileselect.AutoSize = true;
            this.label_fileselect.Location = new System.Drawing.Point(207, 35);
            this.label_fileselect.Name = "label_fileselect";
            this.label_fileselect.Size = new System.Drawing.Size(23, 12);
            this.label_fileselect.TabIndex = 8;
            this.label_fileselect.Text = "...";
            // 
            // button_fileselect
            // 
            this.button_fileselect.Location = new System.Drawing.Point(133, 27);
            this.button_fileselect.Name = "button_fileselect";
            this.button_fileselect.Size = new System.Drawing.Size(68, 29);
            this.button_fileselect.TabIndex = 7;
            this.button_fileselect.Text = "选择文件";
            this.button_fileselect.UseVisualStyleBackColor = true;
            this.button_fileselect.Click += new System.EventHandler(this.button_fileselect_Click);
            // 
            // tbVideoTime
            // 
            this.tbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVideoTime.Location = new System.Drawing.Point(732, 3);
            this.tbVideoTime.Name = "tbVideoTime";
            this.tbVideoTime.ReadOnly = true;
            this.tbVideoTime.Size = new System.Drawing.Size(108, 14);
            this.tbVideoTime.TabIndex = 6;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.AutoSize = false;
            this.trackBar2.Location = new System.Drawing.Point(730, 31);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(109, 28);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(726, 25);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(70, 27);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(57, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "关闭";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(56, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "libvlc.net播放器";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbVideoTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label_fileselect;
        private System.Windows.Forms.Button button_fileselect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.Button Forward_button;
        private System.Windows.Forms.Button Fullscreen_button;
        private System.Windows.Forms.Button Pause_button;
        private System.Windows.Forms.Label ShowIP_label;
    }
}

