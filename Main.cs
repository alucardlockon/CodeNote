using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeNote
{
    public partial class Main : Form
    {
        private static Tomato_work tw; 

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mainEditor.Navigate(System.Environment.CurrentDirectory.ToString() + @"\html\default.html");
            Debug.WriteLine(System.Environment.CurrentDirectory.ToString() + @"\html\default.html");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox.ActiveForm;
            Console.WriteLine("aa");
        }

        private void mainEditor_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void 打开番茄工作面板CtrlShiftTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tw == null || tw.IsDisposed)
            { 
                tw = new Tomato_work();
                tw.Show();
            }
        }
    }
}
