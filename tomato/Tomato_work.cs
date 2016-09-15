using System;
using System.Collections;
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
        //运行时变量
        private string _timeState = "init";
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
        //悬浮窗参数
        public Color CfgMiniwndColor = Color.DarkSlateBlue;
        public Color CfgMiniwndFontcolor = Color.White;
        public double CfgMiniwndOpacity = 0.5d;
        public bool ColorChange;
        //list参数
        private ArrayList _tasklist = new ArrayList(); //tomato_task
        //是否置顶标志
        private static bool _isTop;

        public TomatoWork()
        {
            InitializeComponent();
        }

        private void Tomato_work_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 100, Screen.PrimaryScreen.WorkingArea.Height/2-this.Width/2-100);
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
            if (_timeState == "running_tm")
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
                    _timeState = "running_break";
                    CodeNoteTomato.ShowBalloonTip(100, "CodeNode", "工作时间结束，休息时间开始!!循环:" + _tomatoNowCylce + "/" + _cfgTomatoCylce, ToolTipIcon.Info);
                }
            }
            else if (_timeState == "running_break")
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
                    _timeState = "running_tm";
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
            StartBtn();
        }

        public void StartBtn()
        {
            if (_timeState == "pause")
            {
                _timenow = DateTime.Now;
                _time = DateTime.Now.AddSeconds(_tmspan.TotalSeconds);
                if (_lastState == "running_tm")
                { 
                    _timeState = "running_tm";
                    now_state_lb.Text = @"工作时间";
                }
                else if (_lastState == "running_break")
                {
                    _timeState = "running_break";
                    now_state_lb.Text = @"休息时间";
                }
                else if (_lastState == "running_break" && _tomatoNowCylce == _cfgTomatoCylce)
                {
                    _timeState = "running_break";
                    now_state_lb.Text = @"长休息时间";
                }
            }
            else if (_timeState == "init")
            {
                _timenow = DateTime.Now;
                _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
                _timeState = "running_tm";
                now_state_lb.Text = @"工作时间";
            }
            timer1.Enabled = true;
        }

        /*
         * 暂停 
         */
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            StopBtn();
        }

        public void StopBtn()
        {
            timer1.Enabled = false;
            _lastState = _timeState;
            _timeState = "pause";
            now_state_lb.Text = @"暂停";
        }

        /*
         * 重新开始 
         */
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            _timenow = DateTime.Now;
            _time = DateTime.Now.AddSeconds(_cfgTomatoTm);
            _timeState = "running_tm";
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
            _timeState = "running_tm";
            now_state_lb.Text = @"工作时间";
            _tomatoNowCylce = 1;
            cycle_count_lb.Text = @"循环:" + _tomatoNowCylce + @"/" + _cfgTomatoCylce;
            timer1.Enabled = true;
        }
        /*
         * 设置 
         */
        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            
        }
        /*
         * 新建任务按钮 
         */
        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("config/tomato_list.xml");
            XmlNode listnode=doc.SelectSingleNode("/list");
            XmlNode lastnode = doc.SelectSingleNode("/list").LastChild;
            TomatoTask task = new TomatoTask();
            task.Id = Convert.ToInt32(lastnode.SelectSingleNode("id").InnerText.Trim()) + 1;
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
            nodeTask.AppendChild(nodeId);
            nodeTask.AppendChild(nodeTitle);
            nodeTask.AppendChild(nodeContent);
            nodeTask.AppendChild(nodeDatetime);
            nodeTask.AppendChild(nodeState);
            listnode.AppendChild(nodeTask);
            _tasklist.Insert(0,task);
            doc.Save("config/tomato_list.xml");
            txt_title.Text = "";
            txt_content.Text="";
            txt_time.Text="";
            task_list.DataSource = null;
            task_list.DataSource = _tasklist;
            //勾选任务列表
            int i = 0;
            foreach (TomatoTask task2 in _tasklist)
            {
                if (task2.State == "1")
                {
                    task_list.SetItemChecked(i, true);
                }
                i++;
            }
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
            //初始化任务列表
            _tasklist = GetXmlConfigList("config/tomato_list.xml", "/list/task");
            task_list.DataSource = _tasklist;
            //勾选任务列表
            int i=0;
            foreach (TomatoTask task in _tasklist)
            {
                if(task.State=="1"){
                    task_list.SetItemChecked(i,true);
                }
                i++;
            }

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
                task.Id = Convert.ToInt32(node.SelectSingleNode("id").InnerText.Trim());
                task.Title = node.SelectSingleNode("title").InnerText.Trim();
                task.Content = node.SelectSingleNode("content").InnerText.Trim();
                task.Datetime = node.SelectSingleNode("datetime").InnerText.Trim();
                task.State = node.SelectSingleNode("state").InnerText.Trim();
                list.Add(task);
            }
            list.Reverse();
            return list;
        }
        private string GetXmlConfig(string filename, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return doc.SelectSingleNode(xpath).InnerText.Trim();
        }
        private void SetXmlConfig(string filename, string xpath, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            doc.SelectSingleNode(xpath).InnerText = value.Trim();
            doc.Save(filename);
        }
        private void DelXmlConfig(string filename, string parent_xpath,string childnodename,string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.SelectNodes(parent_xpath);
            foreach (XmlNode node in nodes)
            {
                if (node.SelectSingleNode(childnodename).InnerText.Trim()==value)
                {
                    node.ParentNode.RemoveChild(node);
                    break;
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
            list.Id = Convert.ToInt32(tomatosNode.LastChild.SelectSingleNode("id").InnerText) + 1;
            list.Datetime=DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");
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
            TomatoTask selectedTask=(TomatoTask)task_list.SelectedValue;
            int id=selectedTask.Id;
            
            DelXmlConfig("config/tomato_list.xml", "/list/task","id",Convert.ToString(id));
            _tasklist.Remove(task_list.SelectedValue);
            task_list.DataSource = null;
            task_list.DataSource = _tasklist;
        }

        /**
         * 单击通知栏图标
         */
        private void CodeNoteTomato_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { 
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.Activate();
                }
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
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
            this.Hide();
            e.Cancel = true;
        }

        private void Tomato_work_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Hide();
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
                this.TopMost = _isTop;
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
            int id = ((TomatoTask)_tasklist[e.Index]).Id;
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
