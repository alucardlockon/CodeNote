namespace CodeNote.tomato
{
    partial class Tomato_setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.tomato_tm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.break_tm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tomato_cycle = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.long_break_tm = new System.Windows.Forms.TextBox();
            this.countdown_percent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.countdown_color = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.miniWnd_color = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.miniWnd_fontColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.miniWnd_opacity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作时间(秒)";
            // 
            // tomato_tm
            // 
            this.tomato_tm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tomato_tm.Location = new System.Drawing.Point(144, 35);
            this.tomato_tm.Name = "tomato_tm";
            this.tomato_tm.Size = new System.Drawing.Size(100, 21);
            this.tomato_tm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "休息时间(秒)";
            // 
            // break_tm
            // 
            this.break_tm.Location = new System.Drawing.Point(144, 73);
            this.break_tm.Name = "break_tm";
            this.break_tm.Size = new System.Drawing.Size(100, 21);
            this.break_tm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "循环次数";
            // 
            // tomato_cycle
            // 
            this.tomato_cycle.Location = new System.Drawing.Point(144, 148);
            this.tomato_cycle.Name = "tomato_cycle";
            this.tomato_cycle.Size = new System.Drawing.Size(100, 21);
            this.tomato_cycle.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "长休息时间(秒)";
            // 
            // long_break_tm
            // 
            this.long_break_tm.Location = new System.Drawing.Point(144, 110);
            this.long_break_tm.Name = "long_break_tm";
            this.long_break_tm.Size = new System.Drawing.Size(100, 21);
            this.long_break_tm.TabIndex = 9;
            // 
            // countdown_percent
            // 
            this.countdown_percent.Location = new System.Drawing.Point(144, 185);
            this.countdown_percent.Name = "countdown_percent";
            this.countdown_percent.Size = new System.Drawing.Size(100, 21);
            this.countdown_percent.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "倒数阈值(0-1)";
            // 
            // countdown_color
            // 
            this.countdown_color.Location = new System.Drawing.Point(144, 221);
            this.countdown_color.Name = "countdown_color";
            this.countdown_color.Size = new System.Drawing.Size(100, 21);
            this.countdown_color.TabIndex = 13;
            this.countdown_color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.countdown_color_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "倒数颜色";
            // 
            // miniWnd_color
            // 
            this.miniWnd_color.Location = new System.Drawing.Point(144, 255);
            this.miniWnd_color.Name = "miniWnd_color";
            this.miniWnd_color.Size = new System.Drawing.Size(100, 21);
            this.miniWnd_color.TabIndex = 15;
            this.miniWnd_color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.miniWnd_color_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "悬浮窗颜色";
            // 
            // miniWnd_fontColor
            // 
            this.miniWnd_fontColor.Location = new System.Drawing.Point(144, 292);
            this.miniWnd_fontColor.Name = "miniWnd_fontColor";
            this.miniWnd_fontColor.Size = new System.Drawing.Size(100, 21);
            this.miniWnd_fontColor.TabIndex = 17;
            this.miniWnd_fontColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.miniWnd_fontColor_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "悬浮窗字体颜色";
            // 
            // miniWnd_opacity
            // 
            this.miniWnd_opacity.Location = new System.Drawing.Point(144, 329);
            this.miniWnd_opacity.Name = "miniWnd_opacity";
            this.miniWnd_opacity.Size = new System.Drawing.Size(100, 21);
            this.miniWnd_opacity.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "悬浮窗透明度(0-1)";
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.WhiteSmoke;
            // 
            // Tomato_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 440);
            this.Controls.Add(this.miniWnd_opacity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.miniWnd_fontColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.miniWnd_color);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.countdown_color);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countdown_percent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.long_break_tm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tomato_cycle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.break_tm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tomato_tm);
            this.Controls.Add(this.label1);
            this.Name = "Tomato_setting";
            this.Text = "首选项";
            this.Load += new System.EventHandler(this.Tomato_setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tomato_tm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox break_tm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tomato_cycle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox long_break_tm;
        private System.Windows.Forms.TextBox countdown_percent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox countdown_color;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox miniWnd_color;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox miniWnd_fontColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox miniWnd_opacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}