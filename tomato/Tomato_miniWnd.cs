using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeNote
{
    public partial class Tomato_miniWnd : Form
    {
        Tomato_work tomato_work;
        private Point mPoint = new Point();
        
        public Tomato_miniWnd(Tomato_work tomato_work)
        {
            InitializeComponent();
            this.tomato_work = tomato_work;
        }
        private void Tomato_miniWnd_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-this.Width-200, Screen.PrimaryScreen.WorkingArea.Top );
            this.BackColor = tomato_work.cfg_miniwnd_color;
            time_label.ForeColor = tomato_work.cfg_miniwnd_fontcolor;
            now_state_lb.ForeColor = tomato_work.cfg_miniwnd_fontcolor;
            this.Opacity = tomato_work.cfg_miniwnd_opacity;
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
            if (tomato_work.colorChange)
            {
                time_label.ForeColor=tomato_work.cfg_countdown_color;
            }
            else
            {
                time_label.ForeColor = tomato_work.cfg_miniwnd_fontcolor;
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tomato_work.startBtn();
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tomato_work.stopBtn();
        }

        private void Tomato_miniWnd_DoubleClick(object sender, EventArgs e)
        {
            if (tomato_work != null && !tomato_work.IsDisposed)
            {
                tomato_work.Visible = !tomato_work.Visible;
            }
            else
            {
                tomato_work.Show();
            }
        }

        
    }
}
