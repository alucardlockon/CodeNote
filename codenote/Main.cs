using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeNote.tomato;
using CodeNote.whitenoise;
using Microsoft.Win32;

namespace CodeNote
{
    public partial class Main : Form
    {
        private static TomatoWork tw;
        private static Whitenoise wn;

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

        private void fileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = "notedata\\" + fileList.SelectedNode.FullPath;
            mainEditor.Navigate(System.Environment.CurrentDirectory.ToString() +"\\"+ path);

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEditor.Refresh(WebBrowserRefreshOption.Completely);
        }

    }
}
