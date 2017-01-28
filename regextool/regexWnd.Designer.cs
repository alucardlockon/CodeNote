namespace CodeNote.regextool
{
    partial class regexWnd
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
            this.regText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegYZ = new System.Windows.Forms.Button();
            this.btnJsonYZ = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.regValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regResult = new System.Windows.Forms.TextBox();
            this.regResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // regText
            // 
            this.regText.Location = new System.Drawing.Point(13, 24);
            this.regText.Multiline = true;
            this.regText.Name = "regText";
            this.regText.Size = new System.Drawing.Size(259, 120);
            this.regText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择需要的操作";
            // 
            // btnRegYZ
            // 
            this.btnRegYZ.Location = new System.Drawing.Point(13, 306);
            this.btnRegYZ.Name = "btnRegYZ";
            this.btnRegYZ.Size = new System.Drawing.Size(75, 23);
            this.btnRegYZ.TabIndex = 2;
            this.btnRegYZ.Text = "验证正则";
            this.btnRegYZ.UseVisualStyleBackColor = true;
            this.btnRegYZ.Click += new System.EventHandler(this.btnRegYZ_Click);
            // 
            // btnJsonYZ
            // 
            this.btnJsonYZ.Location = new System.Drawing.Point(105, 306);
            this.btnJsonYZ.Name = "btnJsonYZ";
            this.btnJsonYZ.Size = new System.Drawing.Size(75, 23);
            this.btnJsonYZ.TabIndex = 3;
            this.btnJsonYZ.Text = "验证json";
            this.btnJsonYZ.UseVisualStyleBackColor = true;
            this.btnJsonYZ.Click += new System.EventHandler(this.btnJsonYZ_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(195, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "正则表达式";
            // 
            // regValue
            // 
            this.regValue.Location = new System.Drawing.Point(13, 162);
            this.regValue.Multiline = true;
            this.regValue.Name = "regValue";
            this.regValue.Size = new System.Drawing.Size(259, 51);
            this.regValue.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "验证文本或json";
            // 
            // regResult
            // 
            this.regResult.Location = new System.Drawing.Point(13, 236);
            this.regResult.Multiline = true;
            this.regResult.Name = "regResult";
            this.regResult.Size = new System.Drawing.Size(259, 51);
            this.regResult.TabIndex = 9;
            // 
            // regResultLabel
            // 
            this.regResultLabel.AutoSize = true;
            this.regResultLabel.Location = new System.Drawing.Point(13, 221);
            this.regResultLabel.Name = "regResultLabel";
            this.regResultLabel.Size = new System.Drawing.Size(29, 12);
            this.regResultLabel.TabIndex = 8;
            this.regResultLabel.Text = "结果";
            // 
            // regexWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 341);
            this.Controls.Add(this.regResult);
            this.Controls.Add(this.regResultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.regValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnJsonYZ);
            this.Controls.Add(this.btnRegYZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regText);
            this.Name = "regexWnd";
            this.Text = "文本测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox regText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegYZ;
        private System.Windows.Forms.Button btnJsonYZ;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox regResult;
        private System.Windows.Forms.Label regResultLabel;
    }
}