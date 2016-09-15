namespace CodeNote.tomato
{
    partial class TomatoWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomatoWork));
            this.cmenus_task_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmenus_settings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.首选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置顶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开悬浮窗ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.time_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cycle_count_lb = new System.Windows.Forms.Label();
            this.total_tomato_cnt_lb = new System.Windows.Forms.Label();
            this.today_tomato_cnt_lb = new System.Windows.Forms.Label();
            this.now_state_lb = new System.Windows.Forms.Label();
            this.total_cycle_lb = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.btn_AddTask = new System.Windows.Forms.Button();
            this.txt_content = new System.Windows.Forms.TextBox();
            this.CodeNoteTomato = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmenus_notifybar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开悬浮窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task_list = new System.Windows.Forms.CheckedListBox();
            this.cmenus_task_list.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmenus_settings.SuspendLayout();
            this.cmenus_notifybar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenus_task_list
            // 
            this.cmenus_task_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmenus_task_list.Name = "cmenus_task_list";
            this.cmenus_task_list.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripButton1,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(272, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "开始";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "暂停";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel3.Image")));
            this.toolStripLabel3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel3.Text = "重新开始";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton1.Text = "重新开始循环";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel4.DropDown = this.cmenus_settings;
            this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
            this.toolStripLabel4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel4.Text = "设置";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel4_Click);
            // 
            // cmenus_settings
            // 
            this.cmenus_settings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首选项ToolStripMenuItem,
            this.置顶ToolStripMenuItem,
            this.打开悬浮窗ToolStripMenuItem1,
            this.fqToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem1});
            this.cmenus_settings.Name = "cmenus_settings";
            this.cmenus_settings.OwnerItem = this.toolStripLabel4;
            this.cmenus_settings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmenus_settings.Size = new System.Drawing.Size(137, 136);
            // 
            // 首选项ToolStripMenuItem
            // 
            this.首选项ToolStripMenuItem.Name = "首选项ToolStripMenuItem";
            this.首选项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.首选项ToolStripMenuItem.Text = "首选项";
            this.首选项ToolStripMenuItem.Click += new System.EventHandler(this.首选项ToolStripMenuItem_Click);
            // 
            // 置顶ToolStripMenuItem
            // 
            this.置顶ToolStripMenuItem.Name = "置顶ToolStripMenuItem";
            this.置顶ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.置顶ToolStripMenuItem.Text = "置顶";
            this.置顶ToolStripMenuItem.Click += new System.EventHandler(this.置顶ToolStripMenuItem_Click);
            // 
            // 打开悬浮窗ToolStripMenuItem1
            // 
            this.打开悬浮窗ToolStripMenuItem1.Name = "打开悬浮窗ToolStripMenuItem1";
            this.打开悬浮窗ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.打开悬浮窗ToolStripMenuItem1.Text = "打开悬浮窗";
            this.打开悬浮窗ToolStripMenuItem1.Click += new System.EventHandler(this.打开悬浮窗ToolStripMenuItem1_Click);
            // 
            // fqToolStripMenuItem
            // 
            this.fqToolStripMenuItem.Name = "fqToolStripMenuItem";
            this.fqToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fqToolStripMenuItem.Text = "好番茄";
            this.fqToolStripMenuItem.Click += new System.EventHandler(this.fqToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "历史记录";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_label.Location = new System.Drawing.Point(180, 25);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(75, 32);
            this.time_label.TabIndex = 2;
            this.time_label.Text = "时间";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cycle_count_lb
            // 
            this.cycle_count_lb.AutoSize = true;
            this.cycle_count_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cycle_count_lb.Location = new System.Drawing.Point(8, 34);
            this.cycle_count_lb.Name = "cycle_count_lb";
            this.cycle_count_lb.Size = new System.Drawing.Size(63, 19);
            this.cycle_count_lb.TabIndex = 3;
            this.cycle_count_lb.Text = "循环:0";
            this.cycle_count_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_tomato_cnt_lb
            // 
            this.total_tomato_cnt_lb.AutoSize = true;
            this.total_tomato_cnt_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_tomato_cnt_lb.Location = new System.Drawing.Point(8, 59);
            this.total_tomato_cnt_lb.Name = "total_tomato_cnt_lb";
            this.total_tomato_cnt_lb.Size = new System.Drawing.Size(81, 19);
            this.total_tomato_cnt_lb.TabIndex = 4;
            this.total_tomato_cnt_lb.Text = "番茄数:0";
            this.total_tomato_cnt_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // today_tomato_cnt_lb
            // 
            this.today_tomato_cnt_lb.AutoSize = true;
            this.today_tomato_cnt_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.today_tomato_cnt_lb.Location = new System.Drawing.Point(100, 59);
            this.today_tomato_cnt_lb.Name = "today_tomato_cnt_lb";
            this.today_tomato_cnt_lb.Size = new System.Drawing.Size(63, 19);
            this.today_tomato_cnt_lb.TabIndex = 5;
            this.today_tomato_cnt_lb.Text = "今日:0";
            this.today_tomato_cnt_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // now_state_lb
            // 
            this.now_state_lb.AutoSize = true;
            this.now_state_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.now_state_lb.Location = new System.Drawing.Point(83, 34);
            this.now_state_lb.Name = "now_state_lb";
            this.now_state_lb.Size = new System.Drawing.Size(45, 19);
            this.now_state_lb.TabIndex = 6;
            this.now_state_lb.Text = "暂停";
            this.now_state_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_cycle_lb
            // 
            this.total_cycle_lb.AutoSize = true;
            this.total_cycle_lb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_cycle_lb.Location = new System.Drawing.Point(174, 59);
            this.total_cycle_lb.Name = "total_cycle_lb";
            this.total_cycle_lb.Size = new System.Drawing.Size(81, 19);
            this.total_cycle_lb.TabIndex = 7;
            this.total_cycle_lb.Text = "总循环:0";
            this.total_cycle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_time
            // 
            this.txt_time.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_time.Location = new System.Drawing.Point(1, 83);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(70, 21);
            this.txt_time.TabIndex = 8;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(77, 83);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(191, 21);
            this.txt_title.TabIndex = 9;
            // 
            // btn_AddTask
            // 
            this.btn_AddTask.Location = new System.Drawing.Point(228, 106);
            this.btn_AddTask.Name = "btn_AddTask";
            this.btn_AddTask.Size = new System.Drawing.Size(40, 23);
            this.btn_AddTask.TabIndex = 10;
            this.btn_AddTask.Text = "添加";
            this.btn_AddTask.UseVisualStyleBackColor = true;
            this.btn_AddTask.Click += new System.EventHandler(this.btn_AddTask_Click);
            // 
            // txt_content
            // 
            this.txt_content.Location = new System.Drawing.Point(1, 107);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(225, 21);
            this.txt_content.TabIndex = 11;
            // 
            // CodeNoteTomato
            // 
            this.CodeNoteTomato.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.CodeNoteTomato.BalloonTipText = "world";
            this.CodeNoteTomato.BalloonTipTitle = "Hello";
            this.CodeNoteTomato.ContextMenuStrip = this.cmenus_notifybar;
            this.CodeNoteTomato.Icon = ((System.Drawing.Icon)(resources.GetObject("CodeNoteTomato.Icon")));
            this.CodeNoteTomato.Text = "Tomato";
            this.CodeNoteTomato.Visible = true;
            this.CodeNoteTomato.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CodeNoteTomato_MouseClick);
            // 
            // cmenus_notifybar
            // 
            this.cmenus_notifybar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.打开悬浮窗ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.cmenus_notifybar.Name = "cmenus_notifybar";
            this.cmenus_notifybar.Size = new System.Drawing.Size(137, 70);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 打开悬浮窗ToolStripMenuItem
            // 
            this.打开悬浮窗ToolStripMenuItem.Name = "打开悬浮窗ToolStripMenuItem";
            this.打开悬浮窗ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开悬浮窗ToolStripMenuItem.Text = "打开悬浮窗";
            this.打开悬浮窗ToolStripMenuItem.Click += new System.EventHandler(this.打开悬浮窗ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // task_list
            // 
            this.task_list.ContextMenuStrip = this.cmenus_task_list;
            this.task_list.FormattingEnabled = true;
            this.task_list.HorizontalScrollbar = true;
            this.task_list.Location = new System.Drawing.Point(0, 131);
            this.task_list.Name = "task_list";
            this.task_list.Size = new System.Drawing.Size(272, 324);
            this.task_list.TabIndex = 12;
            this.task_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.task_list_ItemCheck);
            // 
            // TomatoWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 458);
            this.Controls.Add(this.task_list);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.btn_AddTask);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.total_cycle_lb);
            this.Controls.Add(this.now_state_lb);
            this.Controls.Add(this.today_tomato_cnt_lb);
            this.Controls.Add(this.total_tomato_cnt_lb);
            this.Controls.Add(this.cycle_count_lb);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TomatoWork";
            this.Text = "番茄小工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tomato_work_FormClosing);
            this.Load += new System.EventHandler(this.Tomato_work_Load);
            this.Resize += new System.EventHandler(this.Tomato_work_Resize);
            this.cmenus_task_list.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmenus_settings.ResumeLayout(false);
            this.cmenus_notifybar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label cycle_count_lb;
        private System.Windows.Forms.Label total_tomato_cnt_lb;
        private System.Windows.Forms.Label today_tomato_cnt_lb;
        private System.Windows.Forms.Label now_state_lb;
        private System.Windows.Forms.Label total_cycle_lb;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Button btn_AddTask;
        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.ContextMenuStrip cmenus_task_list;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon CodeNoteTomato;
        private System.Windows.Forms.ContextMenuStrip cmenus_notifybar;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel4;
        private System.Windows.Forms.ContextMenuStrip cmenus_settings;
        private System.Windows.Forms.ToolStripMenuItem 首选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 置顶ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.CheckedListBox task_list;
        private System.Windows.Forms.ToolStripMenuItem fqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开悬浮窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开悬浮窗ToolStripMenuItem1;
    }
}