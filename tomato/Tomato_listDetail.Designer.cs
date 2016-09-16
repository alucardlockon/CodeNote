namespace CodeNote.tomato
{
    partial class Tomato_listDetail
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
            this.txt_content = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_sublist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_datetime = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.ch_showList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_content
            // 
            this.txt_content.Location = new System.Drawing.Point(12, 79);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_content.Size = new System.Drawing.Size(288, 97);
            this.txt_content.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_sublist
            // 
            this.txt_sublist.Location = new System.Drawing.Point(12, 197);
            this.txt_sublist.Multiline = true;
            this.txt_sublist.Name = "txt_sublist";
            this.txt_sublist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_sublist.Size = new System.Drawing.Size(288, 107);
            this.txt_sublist.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "子列表";
            // 
            // txt_datetime
            // 
            this.txt_datetime.Location = new System.Drawing.Point(12, 8);
            this.txt_datetime.Name = "txt_datetime";
            this.txt_datetime.Size = new System.Drawing.Size(288, 21);
            this.txt_datetime.TabIndex = 5;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(12, 33);
            this.txt_title.Multiline = true;
            this.txt_title.Name = "txt_title";
            this.txt_title.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_title.Size = new System.Drawing.Size(288, 43);
            this.txt_title.TabIndex = 6;
            // 
            // ch_showList
            // 
            this.ch_showList.AutoSize = true;
            this.ch_showList.Location = new System.Drawing.Point(252, 178);
            this.ch_showList.Name = "ch_showList";
            this.ch_showList.Size = new System.Drawing.Size(48, 16);
            this.ch_showList.TabIndex = 7;
            this.ch_showList.Text = "列表";
            this.ch_showList.UseVisualStyleBackColor = true;
            this.ch_showList.CheckedChanged += new System.EventHandler(this.ch_showList_CheckedChanged);
            // 
            // Tomato_listDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 342);
            this.Controls.Add(this.ch_showList);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.txt_datetime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sublist);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tomato_listDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详情";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_sublist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_datetime;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.CheckBox ch_showList;
    }
}