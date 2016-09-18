using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using CodeNote.domain.tomato;

namespace CodeNote.tomato
{
    public partial class TomatoWork : Form
    {
        //窗体
        private static Tomato_setting _tomatoSetting;
        private static TomatoList _tomatoList;
        private static TomatoFq _tomatoFq;
        private static Tomato_miniWnd _tomatoMiniWnd;
        private static Tomato_listDetail _tomatoListDetail;
        //运行时变量
        public string TimeState = "init";
        private string _lastState = "init";
        private DateTime _time;
        private DateTime _timenow;
        private TimeSpan _tmspan;
        private int _tomatoNowCylce = 1;
        private int _tomatoCount;
        //cfg参数
        private int _cfgTomatoTm = 1500;
        private int _cfgBreakTm = 300;
        private int _cfgLongBreakTm = 900;
        private int _cfgTomatoCylce = 4;
        public Color CfgCountdownColor = Color.Red;
        private double _cfgCountdownPercent = 0.05d;
        public bool CfgShowDetailList = false;
        //悬浮窗参数
        public Color CfgMiniwndColor = Color.DarkSlateBlue;
        public Color CfgMiniwndFontcolor = Color.White;
        public double CfgMiniwndOpacity = 0.5d;
        public bool ColorChange;
        //list参数
        public ArrayList Tasklist = new ArrayList(); //tomato_task
        //是否置顶标志
        private static bool _isTop;

        public TomatoWork()
        {
            InitializeComponent();
        }

        private void Tomato_work_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 100, Screen.PrimaryScreen.WorkingArea.Height/2-Width/2-100);
            time_label.Text = @"00:00";
            Init();
            
        }

        /**
         * 主要计时器方法。
         * time_state:running_tm正在运行工作的状态，running_break正在运行休息的状态
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            _timenow = DateTime.Now;
            if (TimeState == "running_tm")
            {
                _tmspan = _time - _timenow;
                if(_tmspan.Ticks>0){
                    time_label.Text = _tmspan.Minutes + ":" + _tmspan.Seconds;
                    if (_tmspan.TotalSeconds <= _cfgTomatoTm *_cfgCountdownPercent && time_label.ForeColor != CfgCountdownColor)
                    {
                        time_label.ForeColor = CfgCountdownColor;
                        ColorChange = true;
                    }
                    else if (_tmspan.TotalSeconds > _cfgTomatoTm * _cfgCountdownPercent && time_label.ForeColor == CfgCountdownColor)
                    {
                        time_label.ForeColor = Color.Black;
                        ColorChange = false;
                    }
                    nowProgress.Minimum = 0;
                    nowProgress.Maximum = _cfgTomatoTm;
                    nowProgress.Value = _cfgTomatoTm - (int)_tmspan.TotalSeconds;
                }else {
                    _timenow = DateTime.Now;
                    if (_tomatoNowCylce < _cfgTomatoCylce)
                    {
                        _time = DateTime.Now.AddSeconds(_cfgBreakTm);
                        now_state_lb.Text = @"休息时间";
                    }
                    else
                    {
                        _time = DateTime.Now.AddSeconds(_cfgLongBreakTm);
                        now_state_lb.Text = @"长休息时间";
                    }
                    //完成一个番茄工作，增加番茄数
                    _tomatoCount++;
                    if (GetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", "0");
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_today")) + 1));
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_count", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_count")) + 1));
                    AddTomatoToXml();
                    total_tomato_cnt_lb.Text = @"番茄数:" + _tomatoCount;
                    today_tomato_cnt_lb.Text = @"今日:" + GetXmlConfig("config/tomato_user.xml", "/user/tomato_today");
                    TimeState = "running_break";
                    CodeNoteTomato.ShowBalloonTip(100, "CodeNode", "工作时间结束，休息时间开始!!循环:" + _tomatoNowCylce + "/" + _cfgTomatoCylce, ToolTipIcon.Info);
                }
            }
            else if (TimeState == "running_break")
            {
                _tmspan = _time - _timenow;
                if (_tmspan.Ticks > 0)
                {
                    time_label.Text = _tmspan.Minutes + ":" + _tmspan.Seconds;
                    int break_tm = 0;
                    if (now_state_lb.Text == @"长休息时间")
                    {
                        break_tm = _cfgLongBreakTm;
                    }
                    else
                    {
                        break_tm = _cfgBreakTm;
                    }
                    nowProgress.Minimum = 0;
                    nowProgress.Maximum = break_tm;
                    nowProgress.Value = break_tm - (int)_tmspan.TotalSeconds;
                    if (_tmspan.TotalSeconds <= break_tm * _cfgCountdownPercent && time_label.ForeColor != CfgCountdownColor)
                    {
                        time_label.ForeColor = CfgCountdownColor;
                        ColorChange = true;
                    }
                    else if (_tmspan.TotalSeconds > break_tm * _cfgCountdownPercent && time_label.ForeColor == CfgCountdownColor)
                    {
                        time_label.ForeColor = Color.Black;
                        ColorChange = false;
                    }
                }
                else
                {
                    if(_tomatoNowCylce<_cfgTomatoCylce){
                        _tomatoNowCylce++;
                    }else{
                        _tomatoNowCylce = 1 ;
                        SetXmlConfig("config/tomato_user.xml", "/user/total_cycle", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/total_cycle")) + 1));
                        total_cycle_lb.Text = @"总循环:" + GetXmlConfig("config/tomato_user.xml", "/user/total_cycle");
                    }
                    cycle_count_lb.Text = @"循环:" + _tomatoNowCylce + "/" + _cfgTomatoCylce;
                    _timenow = DateTime.Now;
                    _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
                    TimeState = "running_tm";
                    now_state_lb.Text = @"工作时间";
                    CodeNoteTomato.ShowBalloonTip(100, "CodeNode", "休息时间结束，工作时间开始!!循环:" + _tomatoNowCylce + "/" + _cfgTomatoCylce, ToolTipIcon.Info);
                }
            }
            
        }
        /*
         * 开始 
         */
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (TimeState == "pause" || TimeState == "init")
            {
                StartBtn();
                toolStripLabel1.Text = @"暂停";
                if(_tomatoMiniWnd!=null&&!_tomatoMiniWnd.IsDisposed)
                    _tomatoMiniWnd.开始ToolStripMenuItem.Text = @"暂停";
            }else{
                StopBtn();
                toolStripLabel1.Text = @"开始";
                if (_tomatoMiniWnd != null && !_tomatoMiniWnd.IsDisposed)
                    _tomatoMiniWnd.开始ToolStripMenuItem.Text = @"开始";
            }
        }

        public void StartBtn()
        {
            if (TimeState == "pause")
            {
                _timenow = DateTime.Now;
                _time = DateTime.Now.AddSeconds(_tmspan.TotalSeconds);
                if (_lastState == "running_tm")
                { 
                    TimeState = "running_tm";
                    now_state_lb.Text = @"工作时间";
                }
                else if (_lastState == "running_break")
                {
                    TimeState = "running_break";
                    now_state_lb.Text = @"休息时间";
                }
                else if (_lastState == "running_break" && _tomatoNowCylce == _cfgTomatoCylce)
                {
                    TimeState = "running_break";
                    now_state_lb.Text = @"长休息时间";
                }
            }
            else if (TimeState == "init")
            {
                _timenow = DateTime.Now;
                _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
                TimeState = "running_tm";
                now_state_lb.Text = @"工作时间";
            }
            timer1.Enabled = true;
        }

        public void StopBtn()
        {
            timer1.Enabled = false;
            _lastState = TimeState;
            TimeState = "pause";
            now_state_lb.Text = @"暂停";
        }

        /*
         * 重新开始 
         */
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            _timenow = DateTime.Now;
            _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
            TimeState = "running_tm";
            now_state_lb.Text = @"工作时间";
            timer1.Enabled = true;
        }
        /*
         * 重新开始循环 
         */
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _timenow = DateTime.Now;
            _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
            TimeState = "running_tm";
            now_state_lb.Text = @"工作时间";
            _tomatoNowCylce = 1;
            cycle_count_lb.Text = @"循环:" + _tomatoNowCylce + @"/" + _cfgTomatoCylce;
            timer1.Enabled = true;
        }
        
        /*
         * 新建任务按钮 
         */
        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("config/tomato_list.xml");
            XmlNode listnode=doc.SelectSingleNode("/list");
            TomatoTask task = new TomatoTask();
            task.Id = Convert.ToInt32(GetXmlConfig("config/tomato_list.xml","/list/maxid")) + 1;
            
            task.Title = txt_title.Text;
            task.Content = txt_content.Text;
            task.Datetime = txt_time.Text;
            task.State = "0";
            XmlElement nodeTask = doc.CreateElement("task");
            XmlElement nodeId = doc.CreateElement("id");
            nodeId.InnerText = Convert.ToString(task.Id);
            XmlElement nodeTitle = doc.CreateElement("title");
            nodeTitle.InnerText = task.Title;
            XmlElement nodeContent = doc.CreateElement("content");
            nodeContent.InnerText = task.Content;
            XmlElement nodeDatetime = doc.CreateElement("datetime");
            nodeDatetime.InnerText = task.Datetime;
            XmlElement nodeState = doc.CreateElement("state");
            nodeState.InnerText = task.State;
            XmlElement nodeSublist = doc.CreateElement("sublist");
            nodeSublist.InnerText = task.Sublist;
            nodeTask.AppendChild(nodeId);
            nodeTask.AppendChild(nodeTitle);
            nodeTask.AppendChild(nodeContent);
            nodeTask.AppendChild(nodeDatetime);
            nodeTask.AppendChild(nodeState);
            nodeTask.AppendChild(nodeSublist);
            listnode.AppendChild(nodeTask);
            Tasklist.Insert(0,task);
            doc.Save("config/tomato_list.xml");
            txt_title.Text = "";
            txt_content.Text="";
            txt_time.Text="";

            SetXmlConfig("config/tomato_list.xml", "/list/maxid", task.Id.ToString());
            ReloadList(true);
        }
        public void Init()
        {
            //初始化cfg参数
            _cfgTomatoTm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm"));
            _cfgBreakTm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/break_tm"));
            _cfgLongBreakTm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/long_break_tm"));
            _cfgTomatoCylce = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cylce"));
            CfgCountdownColor = ColorTranslator.FromHtml(GetXmlConfig("config/tomato_cfg.xml", "/config/countdown_color"));
            _cfgCountdownPercent = Convert.ToDouble(GetXmlConfig("config/tomato_cfg.xml", "/config/countdown_percent"));
            CfgMiniwndColor = ColorTranslator.FromHtml(GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_color"));
            CfgMiniwndFontcolor = ColorTranslator.FromHtml(GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_fontcolor"));
            CfgMiniwndOpacity = Convert.ToDouble(GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_opacity"));
            CfgShowDetailList = Convert.ToBoolean(GetXmlConfig("config/tomato_cfg.xml", "/config/show_detail_list"));
            //初始化界面
            cycle_count_lb.Text = @"循环:" + _tomatoNowCylce + @"/" + _cfgTomatoCylce;
            _tomatoCount = Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_count"));
            if (GetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date") != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                today_tomato_cnt_lb.Text = @"今日:0";
            }
            else { 
                today_tomato_cnt_lb.Text = @"今日:" + GetXmlConfig("config/tomato_user.xml", "/user/tomato_today");
            }
            total_tomato_cnt_lb.Text = @"番茄数:" + _tomatoCount;
            total_cycle_lb.Text = @"总循环:" + GetXmlConfig("config/tomato_user.xml", "/user/total_cycle");

            ReloadList(false);
        }

        public void ReloadList(bool reloadFlag)
        {
            panel1.Controls.Clear();
            
            //初始化任务列表
            if (Tasklist == null || Tasklist.Count == 0 || reloadFlag)
            {
                Tasklist = GetXmlConfigList("config/tomato_list.xml", "/list/task");
            }

            var task_list = new List<Control>();
            //勾选任务列表
            Graphics graphics = CreateGraphics();
            int i = 0;
            int heigth = 0;
            foreach (TomatoTask task in Tasklist)
            {
                CheckBox chbox = new CheckBox();
                Label lb = new Label();
                chbox.Text = "";
                string content = "";
                if (!string.IsNullOrEmpty(task.Datetime)) content += "[" + task.Datetime + "]";
                if (!string.IsNullOrEmpty(task.Title)) content += "(" + task.Title + ")";
                if (!string.IsNullOrEmpty(task.Content)) content += ":" + task.Content;
                lb.Text = content;
                lb.Name = "label_" + task.Id;
                chbox.Name = "chbox_" + task.Id;
                chbox.AutoSize = false;
                lb.AutoSize = false;
                chbox.CheckAlign = ContentAlignment.TopLeft;
                lb.TextAlign = ContentAlignment.TopLeft;
                int rowcnt = (int)(graphics.MeasureString(lb.Text, lb.Font)).Width / 225;
                int chheigth = rowcnt == 0 ? 1 : (rowcnt > 3) ? 3 : rowcnt + 1;
                lb.Size = new Size(225, 15 * chheigth);
                lb.Location = new Point(18, heigth);
                chbox.Size = new Size(16, 15 * chheigth);
                chbox.Location = new Point(2, heigth);
                heigth += chbox.Size.Height;
                if (task.State == "1")
                {
                    chbox.Checked = true;
                }
                lb.DoubleClick += chbox_DoubleClick;
                chbox.CheckedChanged += chbox_CheckedChanged;
                lb.ContextMenuStrip = cmenus_task_list;
                task_list.Add(chbox);
                task_list.Add(lb);
                i++;
            }
            panel1.Controls.AddRange(task_list.ToArray());

            //刷新悬浮窗任务
            if (_tomatoMiniWnd!=null&&_tomatoMiniWnd.Visible == true)
            {
                _tomatoMiniWnd.ReloadTask();
            }

        }

        private void chbox_CheckedChanged(object sender, EventArgs e)
        {
            string id = ((CheckBox)sender).Name.Replace("chbox_", "");
            bool check = ((CheckBox) sender).Checked;

            XmlDocument doc = new XmlDocument();
            doc.Load("config/tomato_list.xml");
            var selectSingleNode = doc.SelectSingleNode("/list/task[id=" + id + "]");
            if (selectSingleNode != null)
            {
                var singleNode = selectSingleNode.SelectSingleNode("state");
                if (singleNode != null)
                    singleNode.InnerText = (check ? "1" : "0");
            }
            doc.Save("config/tomato_list.xml");
        }

        private void chbox_DoubleClick(object sender, EventArgs e)
        {
            if (_tomatoListDetail != null && !_tomatoListDetail.IsDisposed)
            {
                _tomatoListDetail.Close();
                _tomatoListDetail.Dispose();
            }
            Label lb = (Label)sender;
            string id = lb.Name.Replace("label_", "");
            _tomatoListDetail = new Tomato_listDetail(this,id);

            _tomatoListDetail.Show();
        }


        private ArrayList GetXmlConfigList(string filename,string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes=doc.SelectNodes(xpath);
            ArrayList list = new ArrayList();
            foreach (XmlNode node in nodes)
            {
                TomatoTask task=new TomatoTask();
                var n1 = node.SelectSingleNode("id");
                if (n1 != null)
                    task.Id = Convert.ToInt32(n1.InnerText.Trim());
                var n2 = node.SelectSingleNode("title");
                if (n2 != null)
                    task.Title = n2.InnerText.Trim();
                var n3 = node.SelectSingleNode("content");
                if (n3 != null)
                    task.Content = n3.InnerText.Trim();
                var n4 = node.SelectSingleNode("datetime");
                if (n4 != null)
                    task.Datetime = n4.InnerText.Trim();
                var n5 = node.SelectSingleNode("state");
                if (n5 != null)
                    task.State = n5.InnerText.Trim();
                var n6 = node.SelectSingleNode("sublist");
                if (n6 != null)
                    task.Sublist = n6.InnerText.Trim();
                list.Add(task);
            }
            list.Reverse();
            return list;
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
        private void DelXmlConfig(string filename, string parent_xpath,string childnodename,string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.SelectNodes(parent_xpath);
            if (nodes != null)
                foreach (XmlNode node in nodes)
                {
                    var selectSingleNode = node.SelectSingleNode(childnodename);
                    if (selectSingleNode != null && selectSingleNode.InnerText.Trim()==value)
                    {
                        if (node.ParentNode != null) node.ParentNode.RemoveChild(node);
                        break;
                    }
                }
            doc.Save(filename);
        }
        private void MoveXmlConfig(string filename, string xpath,string upordown)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var n1 = doc.SelectSingleNode(xpath);
            if (n1 != null)
            {
                if (upordown == "down")
                {
                    if (n1.ParentNode != null) n1.ParentNode.InsertBefore(n1, n1.PreviousSibling);
                }
                else if(upordown=="up")
                {
                    if (n1.ParentNode != null) n1.ParentNode.InsertAfter(n1, n1.NextSibling);
                }
            }
            doc.Save(filename);
        }

        private void AddTomatoToXml()
        {
            string filename = "config/tomato_user.xml";
            string xpath="/user/tomatos";

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode tomatosNode=doc.SelectSingleNode(xpath);
            
            domain.tomato.TomatoList list = new domain.tomato.TomatoList();
            if (tomatosNode != null && tomatosNode.LastChild!=null && tomatosNode.LastChild.SelectSingleNode("id") != null)
            {
                list.Id = Convert.ToInt32(tomatosNode.LastChild.SelectSingleNode("id").InnerText) + 1;
            }
            else
            {
                list.Id = 1;
            }
            list.Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            XmlNode newNode = doc.CreateElement("tomato");
            newNode.InnerXml = "<id>" + list.Id + "</id><datetime>" + list.Datetime + "</datetime>";
            tomatosNode.AppendChild(newNode);
            doc.Save(filename);
        }

        /*
         * 右键菜单
         */ 
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id=((ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl.Name.Replace("label_","");
            
            DelXmlConfig("config/tomato_list.xml", "/list/task","id",id);
            ReloadList(true);
        }
        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = ((ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl.Name.Replace("label_", "");

            MoveXmlConfig("config/tomato_list.xml", "/list/task[id=" + id + "]", "up");
            ReloadList(true);
        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = ((ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl.Name.Replace("label_", "");

            MoveXmlConfig("config/tomato_list.xml", "/list/task[id=" + id + "]", "down");
            ReloadList(true);
        }


        /**
         * 单击通知栏图标
         */
        private void CodeNoteTomato_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { 
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

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeNoteTomato.Visible = false;
            Application.Exit();
            Application.ExitThread();
        }

        //最小化到托盘

        private void Tomato_work_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void Tomato_work_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Hide();
            }
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CodeNoteTomato.Visible = false;
            Application.Exit();
            Application.ExitThread();
        }

        private void 首选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoSetting == null || _tomatoSetting.IsDisposed)
            {
                _tomatoSetting = new Tomato_setting(this);
                _tomatoSetting.Show();
            }
        }

        /**
         * 窗口置顶
         */ 
        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                _isTop = !_isTop;
                置顶ToolStripMenuItem.Text = _isTop ? "取消置顶" : "置顶";
                TopMost = _isTop;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_tomatoList == null || _tomatoList.IsDisposed)
            {
                _tomatoList = new TomatoList(this);
                _tomatoList.Show();
            }
        }

        private void task_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id = ((TomatoTask)Tasklist[e.Index]).Id;
            XmlDocument doc = new XmlDocument();
            doc.Load("config/tomato_list.xml");
            doc.SelectSingleNode("/list/task[id="+id+"]").SelectSingleNode("state").InnerText=(e.NewValue==CheckState.Checked?"1":"0"); 
            doc.Save("config/tomato_list.xml");
        }

        private void fqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tomatoFq == null || _tomatoFq.IsDisposed)
            {
                _tomatoFq = new TomatoFq(this);
                _tomatoFq.Show();
            }
            
        }

        private void 打开悬浮窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMiniWnd();
        }
        private void 打开悬浮窗ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenMiniWnd();
        }

        private void OpenMiniWnd()
        {
            if (_tomatoMiniWnd == null || _tomatoMiniWnd.IsDisposed)
            {
                _tomatoMiniWnd = new Tomato_miniWnd(this);
                _tomatoMiniWnd.Show();
            }
        }

        public string TimeLabelText
        {
            get { return time_label.Text; }
            set { time_label.Text = value; }
        }

        public string NowStateLbText
        {
            get { return now_state_lb.Text; }
            set { now_state_lb.Text = value; }
        }

        

    }
}
