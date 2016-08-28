namespace CodeNote
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作时间(秒)";
            // 
            // tomato_tm
            // 
            this.tomato_tm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tomato_tm.Location = new System.Drawing.Point(134, 35);
            this.tomato_tm.Name = "tomato_tm";
            this.tomato_tm.Size = new System.Drawing.Size(100, 21);
            this.tomato_tm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "休息时间(秒)";
            // 
            // break_tm
            // 
            this.break_tm.Location = new System.Drawing.Point(134, 75);
            this.break_tm.Name = "break_tm";
            this.break_tm.Size = new System.Drawing.Size(100, 21);
            this.break_tm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "循环次数";
            // 
            // tomato_cycle
            // 
            this.tomato_cycle.Location = new System.Drawing.Point(134, 155);
            this.tomato_cycle.Name = "tomato_cycle";
            this.tomato_cycle.Size = new System.Drawing.Size(100, 21);
            this.tomato_cycle.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 204);
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
            this.label4.Location = new System.Drawing.Point(30, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "长休息时间(秒)";
            // 
            // long_break_tm
            // 
            this.long_break_tm.Location = new System.Drawing.Point(134, 116);
            this.long_break_tm.Name = "long_break_tm";
            this.long_break_tm.Size = new System.Drawing.Size(100, 21);
            this.long_break_tm.TabIndex = 9;
            // 
            // Tomato_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
            this.Text = "设置";
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
    }
}