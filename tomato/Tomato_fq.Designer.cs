﻿namespace CodeNote.tomato
{
    partial class TomatoFq
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_recover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "注意，如果你不知道这个是干什么用的，请关闭此窗口!";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(48, 64);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(259, 21);
            this.txt_url.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(26, 106);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(215, 106);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "url";
            // 
            // btn_recover
            // 
            this.btn_recover.Location = new System.Drawing.Point(119, 106);
            this.btn_recover.Name = "btn_recover";
            this.btn_recover.Size = new System.Drawing.Size(75, 23);
            this.btn_recover.TabIndex = 5;
            this.btn_recover.Text = "恢复";
            this.btn_recover.UseVisualStyleBackColor = true;
            this.btn_recover.Click += new System.EventHandler(this.btn_recover_Click);
            // 
            // Tomato_fq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 153);
            this.Controls.Add(this.btn_recover);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TomatoFq";
            this.Text = "好番茄";
            this.Load += new System.EventHandler(this.Tomato_fq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_recover;
    }
}