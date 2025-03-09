using System;

namespace client
{
    partial class game_windows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(game_windows));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.voting = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sun = new System.Windows.Forms.PictureBox();
            this.moon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(523, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(268, 203);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(517, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "聊天室";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(34, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "現在狀態：";
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.state.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.state.ForeColor = System.Drawing.Color.Aqua;
            this.state.Location = new System.Drawing.Point(148, 9);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(54, 26);
            this.state.TabIndex = 3;
            this.state.Text = "白天";
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.message.Location = new System.Drawing.Point(523, 287);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(199, 38);
            this.message.TabIndex = 4;
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.send.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.send.ForeColor = System.Drawing.Color.Yellow;
            this.send.Location = new System.Drawing.Point(728, 294);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(63, 31);
            this.send.TabIndex = 5;
            this.send.Text = "送出";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(32, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "總人數：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(33, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "你的身分：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(134, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "8";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Aqua;
            this.label6.Location = new System.Drawing.Point(148, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "身分";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // comboBox
            // 
            this.comboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(233, 51);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(141, 20);
            this.comboBox.TabIndex = 10;
            // 
            // voting
            // 
            this.voting.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.voting.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.voting.ForeColor = System.Drawing.Color.Red;
            this.voting.Location = new System.Drawing.Point(390, 43);
            this.voting.Name = "voting";
            this.voting.Size = new System.Drawing.Size(99, 31);
            this.voting.TabIndex = 11;
            this.voting.Text = "票死他";
            this.voting.UseVisualStyleBackColor = false;
            this.voting.Click += new System.EventHandler(this.voting_Click);
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.number.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.number.ForeColor = System.Drawing.Color.Aqua;
            this.number.Location = new System.Drawing.Point(148, 78);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(54, 26);
            this.number.TabIndex = 12;
            this.number.Text = "編號";
            // 
            // background
            // 
            this.background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("background.BackgroundImage")));
            this.background.Location = new System.Drawing.Point(3, 287);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(710, 158);
            this.background.TabIndex = 13;
            this.background.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Aqua;
            this.label7.Location = new System.Drawing.Point(33, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "你的編號：";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(228, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 26);
            this.label8.TabIndex = 15;
            this.label8.Text = "投票對象：";
            // 
            // sun
            // 
            this.sun.Image = ((System.Drawing.Image)(resources.GetObject("sun.Image")));
            this.sun.Location = new System.Drawing.Point(50, 138);
            this.sun.Name = "sun";
            this.sun.Size = new System.Drawing.Size(152, 143);
            this.sun.TabIndex = 16;
            this.sun.TabStop = false;
            // 
            // moon
            // 
            this.moon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moon.BackgroundImage")));
            this.moon.Location = new System.Drawing.Point(372, 149);
            this.moon.Name = "moon";
            this.moon.Size = new System.Drawing.Size(117, 122);
            this.moon.TabIndex = 17;
            this.moon.TabStop = false;
            this.moon.Visible = false;
            // 
            // game_windows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.moon);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.number);
            this.Controls.Add(this.voting);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.send);
            this.Controls.Add(this.message);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.background);
            this.Controls.Add(this.sun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "game_windows";
            this.Text = "狼人殺";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.game_windows_FormClosing);
            this.Load += new System.EventHandler(this.game_windows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void game_windows_Load(object sender, EventArgs e)
        {          
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button voting;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox sun;
        private System.Windows.Forms.PictureBox moon;
    }
}