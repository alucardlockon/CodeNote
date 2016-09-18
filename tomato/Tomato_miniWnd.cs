using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CodeNote.domain.tomato;
using System.Xml;

namespace CodeNote.tomato
{
    public partial class Tomato_miniWnd : Form
    {
        TomatoWork _tomatoWork;
        private Point mPoint = new Point();
        private int nowindex = 0;
        
        public Tomato_miniWnd(TomatoWork tomato_work)
        {
            InitializeComponent();
            this._tomatoWork = tomato_work;
        }
        private void Tomato_miniWnd_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-this.Width-200, Screen.PrimaryScreen.WorkingArea.Top );
            this.BackColor = _tomatoWork.CfgMiniwndColor;
            time_label.ForeColor = _tomatoWork.CfgMiniwndFontcolor;
            now_state_lb.ForeColor = _tomatoWork.CfgMiniwndFontcolor;
            this.Opacity = _tomatoWork.CfgMiniwndOpacity;
            
            ReloadTask();
        }

        public void ReloadTask()
        {
            if (_tomatoWork.Tasklist != null && _tomatoWork.Tasklist.Count > nowindex)
            {
                task.Text = ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Title + ":" + ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Content;
            }
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
            time_label.Text = _tomatoWork.TimeLabelText;
            now_state_lb.Text = _tomatoWork.NowStateLbText;
            if (_tomatoWork.ColorChange)
            {
                time_label.ForeColor=_tomatoWork.CfgCountdownColor;
            }
            else
            {
                time_label.ForeColor = _tomatoWork.CfgMiniwndFontcolor;
            }
            nowProgress.Minimum = _tomatoWork.nowProgress.Minimum;
            nowProgress.Maximum = _tomatoWork.nowProgress.Maximum;
            nowProgress.Value = _tomatoWork.nowProgress.Value;
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoWork.TimeState == "pause" || _tomatoWork.TimeState == "init")
            {
                _tomatoWork.StartBtn();
                开始ToolStripMenuItem.Text = @"暂停";
                _tomatoWork.toolStripLabel1.Text = @"暂停";
            }
            else
            {
                _tomatoWork.StopBtn();
                开始ToolStripMenuItem.Text = @"开始";
                _tomatoWork.toolStripLabel1.Text = @"开始";
            }
        }

        private void Tomato_miniWnd_DoubleClick(object sender, EventArgs e)
        {
            if (_tomatoWork != null && !_tomatoWork.IsDisposed)
            {
                _tomatoWork.Visible = !_tomatoWork.Visible;
            }
        }

        private void 完成任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoWork.Tasklist != null && _tomatoWork.Tasklist.Count > nowindex)
            {
                ((TomatoTask)_tomatoWork.Tasklist[nowindex]).State = "1";
                CheckBox cb=(CheckBox)_tomatoWork.Controls.Find("chbox_" + ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Id,true)[0];
                cb.Checked = true;
            }
            _tomatoWork.ReloadList(false);
        }

        private void 上一个任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoWork.Tasklist != null && _tomatoWork.Tasklist.Count > nowindex - 1 && nowindex - 1 >= 0)
            {
                nowindex -= 1;
                task.Text = ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Title + ":" + ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Content;
            }
        }

        private void 下一个任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoWork.Tasklist != null && _tomatoWork.Tasklist.Count > nowindex + 1)
            {
                nowindex += 1;
                task.Text = ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Title + ":" + ((TomatoTask)_tomatoWork.Tasklist[nowindex]).Content;
            }
        }

        
    }
}
