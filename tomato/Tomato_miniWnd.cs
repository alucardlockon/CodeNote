using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CodeNote.tomato
{
    public partial class Tomato_miniWnd : Form
    {
        TomatoWork tomato_work;
        private Point mPoint = new Point();
        
        public Tomato_miniWnd(TomatoWork tomato_work)
        {
            InitializeComponent();
            this.tomato_work = tomato_work;
        }
        private void Tomato_miniWnd_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-this.Width-200, Screen.PrimaryScreen.WorkingArea.Top );
            this.BackColor = tomato_work.CfgMiniwndColor;
            time_label.ForeColor = tomato_work.CfgMiniwndFontcolor;
            now_state_lb.ForeColor = tomato_work.CfgMiniwndFontcolor;
            this.Opacity = tomato_work.CfgMiniwndOpacity;
        }

        private void Tomato_miniWnd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mPoint.X = e.X;
                mPoint.Y = e.Y;
            }
        }

        //拖动窗口
        private void Tomato_miniWnd_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            } 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_label.Text = tomato_work.TimeLabelText;
            now_state_lb.Text = tomato_work.NowStateLbText;
            if (tomato_work.ColorChange)
            {
                time_label.ForeColor=tomato_work.CfgCountdownColor;
            }
            else
            {
                time_label.ForeColor = tomato_work.CfgMiniwndFontcolor;
            }
            nowProgress.Minimum = tomato_work.nowProgress.Minimum;
            nowProgress.Maximum = tomato_work.nowProgress.Maximum;
            nowProgress.Value = tomato_work.nowProgress.Value;
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tomato_work.TimeState == "pause" || tomato_work.TimeState == "init")
            {
                tomato_work.StartBtn();
                开始ToolStripMenuItem.Text = @"暂停";
                tomato_work.toolStripLabel1.Text = @"暂停";
            }
            else
            {
                tomato_work.StopBtn();
                开始ToolStripMenuItem.Text = @"开始";
                tomato_work.toolStripLabel1.Text = @"开始";
            }
        }

        private void Tomato_miniWnd_DoubleClick(object sender, EventArgs e)
        {
            Debug.WriteLine(tomato_work + "," + tomato_work.IsDisposed);
            if (tomato_work != null && !tomato_work.IsDisposed)
            {
                tomato_work.Visible = !tomato_work.Visible;
            }
            
        }

        
    }
}
