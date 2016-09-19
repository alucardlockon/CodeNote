using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CodeNote.tomato;
using CodeNote.whitenoise;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Xml;
using CodeNote.codenote;

namespace CodeNote
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]//com+可见
    public partial class Main : Form
    {
        private static TomatoWork tw;
        private static Whitenoise wn;
        private static Gist_settings _gistSettings;
        private static Gist_add _gist;
        private static Settings _settings;
        private static Gist_download _gistDownload;

        public Main()
        {
            InitializeComponent();
            base.SetStyle(
             ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制
             ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
             ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁
             ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件
             ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明
             true);                                         // 设置以上值为 true
            base.UpdateStyles();

            //注册表项目
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true); //该项必须已存在
            if (software == null)
            {
                software = key.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION");
                if (software != null) software.SetValue("CodeNote.exe", 11001, RegistryValueKind.DWord);
            }
            key.Close();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            mainEditor.ObjectForScripting = this;
            mainEditor.Navigate(System.Environment.CurrentDirectory.ToString() + @"\html\index.html");
            
            //绑定树形菜单
            BindFileList();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox.ActiveForm;
        }

        private void mainEditor_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void 打开番茄工作面板CtrlShiftTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tw == null || tw.IsDisposed)
            {
                tw = new TomatoWork();
                tw.Show();
            }
            else if(tw!=null&&tw.Visible==false)
            {
               tw.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        private void BindFileList()
        {
            DirectoryInfo root=new DirectoryInfo("notedata");

            DirectoryInfo[] rootdinfos = root.GetDirectories();

            var tnd = new List<TreeNode>();
            foreach (DirectoryInfo dinfo in rootdinfos)
            {
                var treeNode = new TreeNode();
                treeNode.ImageKey = "folder";
                treeNode.SelectedImageKey = "folder";
                treeNode.Text = dinfo.Name;
                treeNode.Nodes.AddRange(GetChildTreeNodeList(dinfo));
                tnd.Add(treeNode);
            }
            fileList.Nodes.AddRange((TreeNode[])tnd.ToArray());

            FileInfo[] rootfinfos = root.GetFiles();

            var tn = new List<TreeNode>();
            foreach (FileInfo finfo in rootfinfos)
            {
                var treeNode = new TreeNode();
                treeNode.ImageKey = "file";
                treeNode.SelectedImageKey = "file";
                treeNode.Text = finfo.Name;
                tn.Add(treeNode);
            }
            fileList.Nodes.AddRange((TreeNode[])tn.ToArray());

        }
        private TreeNode[] GetChildTreeNodeList(DirectoryInfo parentdinfo)
        {
            DirectoryInfo root = parentdinfo;

            DirectoryInfo[] rootdinfos = root.GetDirectories();

            var tnd = new List<TreeNode>();
            foreach (DirectoryInfo dinfo in rootdinfos)
            {
                var treeNode = new TreeNode();
                treeNode.ImageKey = "folder";
                treeNode.SelectedImageKey = "folder";
                treeNode.Text = dinfo.Name;
                treeNode.Nodes.AddRange(GetChildTreeNodeList(dinfo));
                tnd.Add(treeNode);
            }

            FileInfo[] rootfinfos = root.GetFiles();

            var tn = new List<TreeNode>();
            foreach (FileInfo finfo in rootfinfos)
            {
                if (finfo.Extension == ".md" || finfo.Extension == ".html") { 
                    var treeNode = new TreeNode();
                    treeNode.ImageKey = "file";
                    treeNode.SelectedImageKey = "file";
                    treeNode.Text = finfo.Name;
                    treeNode.Tag = finfo.FullName;
                    tn.Add(treeNode);
                }
            }
            tnd.AddRange(tn);
            return (TreeNode[])tnd.ToArray();
            
        }

        //去除重绘
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }

        private void 白噪音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wn == null || wn.IsDisposed)
            {
                wn = new Whitenoise();
                wn.Show();
            }
            else if (wn != null && wn.Visible == false)
            {
                wn.Show();
            }
        }

        //双击文件节点
        private void fileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (fileList.SelectedNode != null)
            {
                string path = "notedata\\" + fileList.SelectedNode.FullPath;
                string content = "";
                FileInfo fi=new FileInfo(System.Environment.CurrentDirectory.ToString() +"\\"+path);
                try
                {
                    FileStream fs = fi.OpenRead();
                    int fsLen = (int)fs.Length;
                    byte[] heByte = new byte[fsLen];
                    int r = fs.Read(heByte, 0, heByte.Length);
                    content = System.Text.Encoding.UTF8.GetString(heByte);
                    fs.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                mainEditor.Document.InvokeScript("loadLocalFile", new object[] { path, fileList.SelectedNode.Text,content });
                this.Text = fileList.SelectedNode.Text+"-CodeNote";
            }
        }

        public void SaveNote(string path,string name,string content)
        {
            FileInfo fi=new FileInfo(System.Environment.CurrentDirectory.ToString() +"\\"+path);
            FileStream fs = fi.OpenWrite();
            byte[] data = System.Text.Encoding.Default.GetBytes(content); 
            fs.Write(data,0,data.Length);
            fs.Flush();
            fs.Close();
        }


        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEditor.Refresh(WebBrowserRefreshOption.Completely);
            fileList.Nodes.Clear();
            BindFileList();
        }

        private void fileList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (fileList.SelectedNode != null)
                {
                    string path = "notedata\\" + ((TreeNode)(e.Item)).FullPath;
                    var files = new string[1];
                    files[0] = System.Environment.CurrentDirectory.ToString() + "\\" + path;
                    DataObject data = new DataObject(DataFormats.FileDrop, files);
                    data.SetData(DataFormats.StringFormat, files[0]);  
                    fileList.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEditor.Navigate("about:blank");
            mainEditor.Navigate(System.Environment.CurrentDirectory.ToString() + @"\html\index.html");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/alucardlockon/CodeNote");
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedNode != null)
            {
                string path = "notedata\\" + fileList.SelectedNode.FullPath;
                mainEditor.Document.InvokeScript("saveToLocalFile", new object[] { path, fileList.SelectedNode.Text });
            }
        }

        private void fileList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            TreeNode tn = fileList.GetNodeAt(point);
            fileList.SelectedNode = tn;
        }

        //编辑模式切换
        private void 所见即所得ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEditor.Document.InvokeScript("setEditorMode", new object[] { 1 });
        }

        private void 查看笔记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEditor.Document.InvokeScript("setEditorMode", new object[] { 2 });
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainEditor.Document.InvokeScript("setEditorMode", new object[] { 3 });
        }

        //文件管理
        private void 上传代码片段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory.ToString() + @"\filedata\snippets");
        }

        private void 上传代码文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory.ToString() + @"\filedata\codes");
        }

        private void 上传模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory.ToString() + @"\filedata\models");
        }

        private void 上传项目文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory.ToString() + @"\filedata\projects");
        }

        private void 上传工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory.ToString() + @"\filedata\utils");
        }

        //用编辑器打开
        private void 用atom打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedNode != null)
            {
                string path = "notedata\\" + fileList.SelectedNode.FullPath;
                try
                {
                    string editorpath = GetXmlConfig("config/codenote_settings.xml", "/setting/atom-bin");
                    System.Diagnostics.Process.Start(editorpath, System.Environment.CurrentDirectory.ToString() + @"\" + path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void 用sublime打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedNode != null)
            {
                string path = "notedata\\" + fileList.SelectedNode.FullPath;
                try
                {
                    string editorpath = GetXmlConfig("config/codenote_settings.xml", "/setting/sublime-bin");
                    System.Diagnostics.Process.Start(editorpath, System.Environment.CurrentDirectory.ToString() + @"\" + path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void 用notepadd打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedNode != null)
            {
                string path = "notedata\\" + fileList.SelectedNode.FullPath;
                try
                {
                    string editorpath = GetXmlConfig("config/codenote_settings.xml", "/setting/npp-bin");
                    System.Diagnostics.Process.Start(editorpath, System.Environment.CurrentDirectory.ToString() + @"\" + path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string GetXmlConfig(string filename, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var selectSingleNode = doc.SelectSingleNode(xpath);
            if (selectSingleNode != null) return selectSingleNode.InnerText.Trim();
            return null;
        }
        private void SetXmlConfig(string filename, string xpath, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var n1 = doc.SelectSingleNode(xpath);
            if (n1 != null) n1.InnerText = value.Trim();
            doc.Save(filename);
        }

        private void 首选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_settings == null || _settings.IsDisposed)
            {
                _settings = new Settings();
                _settings.Show();
            }
            else if (_settings != null && _settings.Visible == false)
            {
                _settings.Show();
            }
        }

        private void gist设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gistSettings == null || _gistSettings.IsDisposed)
            {
                _gistSettings = new Gist_settings();
                _gistSettings.Show();
            }
            else if (_gistSettings != null && _gistSettings.Visible == false)
            {
                _gistSettings.Show();
            }
        }

        private void 上传gistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gist == null || _gist.IsDisposed)
            {
                _gist = new Gist_add();
                _gist.Show();
            }
            else if (_gist != null && _gist.Visible == false)
            {
                _gist.Show();
            }
        }

        private void 下载gistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gistDownload == null || _gistDownload.IsDisposed)
            {
                _gistDownload = new Gist_download();
                _gistDownload.Show();
            }
            else if (_gistDownload != null && _gistDownload.Visible == false)
            {
                _gistDownload.Show();
            }
        }

        private void 打开gist页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string page = GetXmlConfig("config/codenote_gists.xml", "/gists/page");
            System.Diagnostics.Process.Start("iexplore.exe", page);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        private void 打开番茄工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打开番茄工作面板CtrlShiftTToolStripMenuItem_Click(sender, e);
        }

        private void 首选项ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            首选项ToolStripMenuItem_Click(sender, e);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void CodeNoteIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Visible)
                {
                    Hide();
                }
                else
                {
                    Show();
                    Activate();
                }
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Hide();
            }
        }


    }
}
