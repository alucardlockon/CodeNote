namespace CodeNote
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.首选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.所见即所得ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传代码片段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传代码文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传项目文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传gistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载gistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开gist页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gist设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.番茄工作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.白噪音ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainEditor = new System.Windows.Forms.WebBrowser();
            this.CodeNoteIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmenus_notifybar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开悬浮窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileList = new System.Windows.Forms.TreeView();
            this.cmenus_filelist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.cmenus_notifybar.SuspendLayout();
            this.cmenus_filelist.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(-5366, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(241, 531);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.文件管理ToolStripMenuItem,
            this.gistToolStripMenuItem,
            this.番茄工作ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1404, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.新建NToolStripMenuItem_Click);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.退出ToolStripMenuItem.Text = "退出(&Q)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首选项ToolStripMenuItem,
            this.所见即所得ToolStripMenuItem,
            this.查看笔记ToolStripMenuItem,
            this.编辑ToolStripMenuItem1,
            this.刷新ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.编辑ToolStripMenuItem.Text = "编辑/查看(&E)";
            // 
            // 首选项ToolStripMenuItem
            // 
            this.首选项ToolStripMenuItem.Name = "首选项ToolStripMenuItem";
            this.首选项ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.首选项ToolStripMenuItem.Text = "首选项(&O)";
            // 
            // 所见即所得ToolStripMenuItem
            // 
            this.所见即所得ToolStripMenuItem.Name = "所见即所得ToolStripMenuItem";
            this.所见即所得ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.所见即所得ToolStripMenuItem.Text = "所见即所得(&I)";
            this.所见即所得ToolStripMenuItem.Click += new System.EventHandler(this.所见即所得ToolStripMenuItem_Click);
            // 
            // 查看笔记ToolStripMenuItem
            // 
            this.查看笔记ToolStripMenuItem.Name = "查看笔记ToolStripMenuItem";
            this.查看笔记ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看笔记ToolStripMenuItem.Text = "查看模式(&V)";
            this.查看笔记ToolStripMenuItem.Click += new System.EventHandler(this.查看笔记ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem1
            // 
            this.编辑ToolStripMenuItem1.Name = "编辑ToolStripMenuItem1";
            this.编辑ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem1.Text = "编辑模式(&E)";
            this.编辑ToolStripMenuItem1.Click += new System.EventHandler(this.编辑ToolStripMenuItem1_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.刷新ToolStripMenuItem.Text = "刷新(&R)";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 文件管理ToolStripMenuItem
            // 
            this.文件管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传代码片段ToolStripMenuItem,
            this.上传代码文件ToolStripMenuItem,
            this.上传模板ToolStripMenuItem,
            this.上传项目文件ToolStripMenuItem,
            this.上传工具ToolStripMenuItem});
            this.文件管理ToolStripMenuItem.Name = "文件管理ToolStripMenuItem";
            this.文件管理ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.文件管理ToolStripMenuItem.Text = "文件管理(&M)";
            // 
            // 上传代码片段ToolStripMenuItem
            // 
            this.上传代码片段ToolStripMenuItem.Name = "上传代码片段ToolStripMenuItem";
            this.上传代码片段ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上传代码片段ToolStripMenuItem.Text = "上传代码片段";
            // 
            // 上传代码文件ToolStripMenuItem
            // 
            this.上传代码文件ToolStripMenuItem.Name = "上传代码文件ToolStripMenuItem";
            this.上传代码文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上传代码文件ToolStripMenuItem.Text = "上传代码文件";
            // 
            // 上传模板ToolStripMenuItem
            // 
            this.上传模板ToolStripMenuItem.Name = "上传模板ToolStripMenuItem";
            this.上传模板ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上传模板ToolStripMenuItem.Text = "上传模板";
            // 
            // 上传项目文件ToolStripMenuItem
            // 
            this.上传项目文件ToolStripMenuItem.Name = "上传项目文件ToolStripMenuItem";
            this.上传项目文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上传项目文件ToolStripMenuItem.Text = "上传项目文件";
            // 
            // 上传工具ToolStripMenuItem
            // 
            this.上传工具ToolStripMenuItem.Name = "上传工具ToolStripMenuItem";
            this.上传工具ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.上传工具ToolStripMenuItem.Text = "上传工具";
            // 
            // gistToolStripMenuItem
            // 
            this.gistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传gistToolStripMenuItem,
            this.下载gistToolStripMenuItem,
            this.打开gist页面ToolStripMenuItem,
            this.gist设置ToolStripMenuItem});
            this.gistToolStripMenuItem.Name = "gistToolStripMenuItem";
            this.gistToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.gistToolStripMenuItem.Text = "Gist";
            // 
            // 上传gistToolStripMenuItem
            // 
            this.上传gistToolStripMenuItem.Name = "上传gistToolStripMenuItem";
            this.上传gistToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.上传gistToolStripMenuItem.Text = "上传gist";
            // 
            // 下载gistToolStripMenuItem
            // 
            this.下载gistToolStripMenuItem.Name = "下载gistToolStripMenuItem";
            this.下载gistToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.下载gistToolStripMenuItem.Text = "下载gist";
            // 
            // 打开gist页面ToolStripMenuItem
            // 
            this.打开gist页面ToolStripMenuItem.Name = "打开gist页面ToolStripMenuItem";
            this.打开gist页面ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.打开gist页面ToolStripMenuItem.Text = "打开gist页面";
            // 
            // gist设置ToolStripMenuItem
            // 
            this.gist设置ToolStripMenuItem.Name = "gist设置ToolStripMenuItem";
            this.gist设置ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.gist设置ToolStripMenuItem.Text = "gist设置";
            // 
            // 番茄工作ToolStripMenuItem
            // 
            this.番茄工作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem,
            this.白噪音ToolStripMenuItem});
            this.番茄工作ToolStripMenuItem.Name = "番茄工作ToolStripMenuItem";
            this.番茄工作ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.番茄工作ToolStripMenuItem.Text = "工具(&T)";
            // 
            // 打开番茄工作面板CtrlShiftTToolStripMenuItem
            // 
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem.Name = "打开番茄工作面板CtrlShiftTToolStripMenuItem";
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem.Text = "打开番茄工作面板(&T)";
            this.打开番茄工作面板CtrlShiftTToolStripMenuItem.Click += new System.EventHandler(this.打开番茄工作面板CtrlShiftTToolStripMenuItem_Click);
            // 
            // 白噪音ToolStripMenuItem
            // 
            this.白噪音ToolStripMenuItem.Name = "白噪音ToolStripMenuItem";
            this.白噪音ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.白噪音ToolStripMenuItem.Text = "白噪音工具(&W)";
            this.白噪音ToolStripMenuItem.Click += new System.EventHandler(this.白噪音ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.关于ToolStripMenuItem.Text = "2016Ywh-CodeNote";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aboutToolStripMenuItem.Text = "About(&A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainEditor
            // 
            this.mainEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainEditor.Location = new System.Drawing.Point(206, 31);
            this.mainEditor.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainEditor.Name = "mainEditor";
            this.mainEditor.ScriptErrorsSuppressed = true;
            this.mainEditor.Size = new System.Drawing.Size(1198, 531);
            this.mainEditor.TabIndex = 5;
            this.mainEditor.Url = new System.Uri("", System.UriKind.Relative);
            this.mainEditor.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mainEditor_DocumentCompleted);
            // 
            // CodeNoteIcon
            // 
            this.CodeNoteIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.CodeNoteIcon.BalloonTipText = "world";
            this.CodeNoteIcon.BalloonTipTitle = "Hello";
            this.CodeNoteIcon.ContextMenuStrip = this.cmenus_notifybar;
            this.CodeNoteIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("CodeNoteIcon.Icon")));
            this.CodeNoteIcon.Text = "Tomato";
            this.CodeNoteIcon.Visible = true;
            // 
            // cmenus_notifybar
            // 
            this.cmenus_notifybar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.打开悬浮窗ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.cmenus_notifybar.Name = "cmenus_notifybar";
            this.cmenus_notifybar.Size = new System.Drawing.Size(137, 70);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 打开悬浮窗ToolStripMenuItem
            // 
            this.打开悬浮窗ToolStripMenuItem.Name = "打开悬浮窗ToolStripMenuItem";
            this.打开悬浮窗ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开悬浮窗ToolStripMenuItem.Text = "打开悬浮窗";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "退出";
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileList.ContextMenuStrip = this.cmenus_filelist;
            this.fileList.ImageKey = "file";
            this.fileList.ImageList = this.imageList1;
            this.fileList.Location = new System.Drawing.Point(0, 31);
            this.fileList.Name = "fileList";
            this.fileList.SelectedImageIndex = 0;
            this.fileList.Size = new System.Drawing.Size(200, 531);
            this.fileList.TabIndex = 6;
            this.fileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.fileList_ItemDrag);
            this.fileList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileList_NodeMouseClick);
            this.fileList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileList_NodeMouseDoubleClick);
            // 
            // cmenus_filelist
            // 
            this.cmenus_filelist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.编辑ToolStripMenuItem2,
            this.重命名ToolStripMenuItem,
            this.删除ToolStripMenuItem1});
            this.cmenus_filelist.Name = "cmenus_filelist";
            this.cmenus_filelist.Size = new System.Drawing.Size(113, 92);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 编辑ToolStripMenuItem2
            // 
            this.编辑ToolStripMenuItem2.Name = "编辑ToolStripMenuItem2";
            this.编辑ToolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem2.Text = "编辑";
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file");
            this.imageList1.Images.SetKeyName(1, "folder");
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 565);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.mainEditor);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "CodeNote Version 1.00";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmenus_notifybar.ResumeLayout(false);
            this.cmenus_filelist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 首选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.WebBrowser mainEditor;
        private System.Windows.Forms.ToolStripMenuItem 番茄工作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开番茄工作面板CtrlShiftTToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon CodeNoteIcon;
        private System.Windows.Forms.ContextMenuStrip cmenus_notifybar;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开悬浮窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TreeView fileList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 白噪音ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查看笔记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmenus_filelist;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 所见即所得ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传代码片段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传代码文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传项目文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传gistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载gistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开gist页面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gist设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
    }
}

