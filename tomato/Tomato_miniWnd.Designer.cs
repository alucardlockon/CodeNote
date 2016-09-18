namespace CodeNote.tomato
{
    partial class Tomato_miniWnd
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
            this.time_label = new System.Windows.Forms.Label();
            this.now_state_lb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完成任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上一个任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一个任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task = new System.Windows.Forms.Label();
            this.nowProgress = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Consolas", 10F);
            this.time_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.time_label.Location = new System.Drawing.Point(123, 0);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(40, 17);
            this.time_label.TabIndex = 3;
            this.time_label.Text = "时间";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // now_state_lb
            // 
            this.now_state_lb.AutoSize = true;
            this.now_state_lb.Font = new System.Drawing.Font("Consolas", 10F);
            this.now_state_lb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.now_state_lb.Location = new System.Drawing.Point(0, 0);
            this.now_state_lb.Name = "now_state_lb";
            this.now_state_lb.Size = new System.Drawing.Size(40, 17);
            this.now_state_lb.TabIndex = 7;
            this.now_state_lb.Text = "暂停";
            this.now_state_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.完成任务ToolStripMenuItem,
            this.上一个任务ToolStripMenuItem,
            this.下一个任务ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 114);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 完成任务ToolStripMenuItem
            // 
            this.完成任务ToolStripMenuItem.Name = "完成任务ToolStripMenuItem";
            this.完成任务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.完成任务ToolStripMenuItem.Text = "完成此任务";
            this.完成任务ToolStripMenuItem.Click += new System.EventHandler(this.完成任务ToolStripMenuItem_Click);
            // 
            // 上一个任务ToolStripMenuItem
            // 
            this.上一个任务ToolStripMenuItem.Name = "上一个任务ToolStripMenuItem";
            this.上一个任务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.上一个任务ToolStripMenuItem.Text = "上一个任务";
            this.上一个任务ToolStripMenuItem.Click += new System.EventHandler(this.上一个任务ToolStripMenuItem_Click);
            // 
            // 下一个任务ToolStripMenuItem
            // 
            this.下一个任务ToolStripMenuItem.Name = "下一个任务ToolStripMenuItem";
            this.下一个任务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.下一个任务ToolStripMenuItem.Text = "下一个任务";
            this.下一个任务ToolStripMenuItem.Click += new System.EventHandler(this.下一个任务ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // task
            // 
            this.task.AutoSize = true;
            this.task.Font = new System.Drawing.Font("Consolas", 7F);
            this.task.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.task.Location = new System.Drawing.Point(1, 19);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(25, 12);
            this.task.TabIndex = 8;
            this.task.Text = "任务";
            // 
            // nowProgress
            // 
            this.nowProgress.Location = new System.Drawing.Point(4, 35);
            this.nowProgress.Name = "nowProgress";
            this.nowProgress.Size = new System.Drawing.Size(170, 2);
            this.nowProgress.TabIndex = 9;
            // 
            // Tomato_miniWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(180, 38);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.nowProgress);
            this.Controls.Add(this.task);
            this.Controls.Add(this.now_state_lb);
            this.Controls.Add(this.time_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tomato_miniWnd";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tomato_miniWnd";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.Tomato_miniWnd_Load);
            this.DoubleClick += new System.EventHandler(this.Tomato_miniWnd_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tomato_miniWnd_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tomato_miniWnd_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label now_state_lb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.Label task;
        private System.Windows.Forms.ToolStripMenuItem 完成任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上一个任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下一个任务ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar nowProgress;
    }
}