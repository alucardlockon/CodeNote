using CodeNote.domain.tomato;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote
{
    public partial class Tomato_work : Form
    {
        //窗体
        private static Tomato_setting tomato_setting;
        private static Tomato_list tomato_list;
        private static Tomato_fq tomato_fq;
        //运行时变量
        private string time_state = "init";
        private DateTime time = new DateTime();
        private DateTime timenow = new DateTime();
        private TimeSpan tmspan=new TimeSpan();
        private int tomato_now_cylce = 1;
        private int tomato_count = 0;
        //cfg参数
        private int cfg_tomato_tm = 1500;
        private int cfg_break_tm = 300;
        private int cfg_long_break_tm = 900;
        private int cfg_tomato_cylce = 4;
        //list参数
        private ArrayList tasklist = new ArrayList(); //tomato_task
        //是否置顶标志
        private static bool isTop=false;

        public Tomato_work()
        {
            InitializeComponent();
        }

        private void Tomato_work_Load(object sender, EventArgs e)
        {
            time_label.Text = "00:00";
            Init();
        }

        /**
         * 主要计时器方法。
         * time_state:running_tm正在运行工作的状态，running_break正在运行休息的状态
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timenow = DateTime.Now;
            if (time_state == "running_tm")
            {
                tmspan = time - timenow;
                if(tmspan.Ticks>0){
                    time_label.Text = tmspan.Minutes + ":" + tmspan.Seconds;
                }else {
                    timenow = DateTime.Now;
                    if (tomato_now_cylce < cfg_tomato_cylce)
                    {
                        time = DateTime.Now.AddSeconds(cfg_break_tm);
                        now_state_lb.Text = "休息时间";
                    }
                    else
                    {
                        time = DateTime.Now.AddSeconds(cfg_long_break_tm);
                        now_state_lb.Text = "长休息时间";
                    }
                    //完成一个番茄工作，增加番茄数
                    tomato_count++;
                    if (GetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", "0");
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_today")) + 1));
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_count", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_count")) + 1));
                    AddTomatoToXml();
                    total_tomato_cnt_lb.Text = "番茄数:" + tomato_count;
                    today_tomato_cnt_lb.Text = "今日:" + GetXmlConfig("config/tomato_user.xml", "/user/tomato_today");
                    time_state = "running_break";
                    CodeNoteTomato.ShowBalloonTip(100, "CodeNode", "工作时间结束，休息时间开始!!循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce, ToolTipIcon.Info);
                }
            }
            else if (time_state == "running_break")
            {
                tmspan = time - timenow;
                if (tmspan.Ticks > 0)
                {
                    time_label.Text = tmspan.Minutes + ":" + tmspan.Seconds;
                }
                else
                {
                    if(tomato_now_cylce<cfg_tomato_cylce){
                        tomato_now_cylce++;
                    }else{
                        tomato_now_cylce = 1 ;
                        SetXmlConfig("config/tomato_user.xml", "/user/total_cycle", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/total_cycle") + 1)));
                        total_cycle_lb.Text = "总循环:" + GetXmlConfig("config/tomato_user.xml", "/user/total_cycle");
                    }
                    cycle_count_lb.Text = "循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce;
                    timenow = DateTime.Now;
                    time = DateTime.Now.AddSeconds(cfg_tomato_tm);
                    time_state = "running_tm";
                    now_state_lb.Text = "工作时间";
                    CodeNoteTomato.ShowBalloonTip(100, "CodeNode", "休息时间结束，工作时间开始!!循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce, ToolTipIcon.Info);
                }
            }
        }
        /*
         * 开始 
         */
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (time_state == "pause")
            {
                timenow = DateTime.Now ;
                time = DateTime.Now.AddSeconds(tmspan.TotalSeconds);
            }
            else if (time_state == "init")
            {
                timenow = DateTime.Now;
                time = DateTime.Now.AddSeconds(cfg_tomato_tm);
            }
            time_state = "running_tm";
            now_state_lb.Text = "工作时间";
            timer1.Enabled = true;
        }
        /*
         * 暂停 
         */
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            time_state = "pause";
            now_state_lb.Text = "暂停";
        }
        /*
         * 重新开始 
         */
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            timenow = DateTime.Now;
            time = DateTime.Now.AddSeconds(cfg_tomato_tm);
            time_state = "running_tm";
            now_state_lb.Text = "工作时间";
            timer1.Enabled = true;
        }
        /*
         * 重新开始循环 
         */
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timenow = DateTime.Now;
            time = DateTime.Now.AddSeconds(cfg_tomato_tm);
            time_state = "running_tm";
            now_state_lb.Text = "工作时间";
            tomato_now_cylce = 1;
            cycle_count_lb.Text = "循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce;
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
            XmlElement node_task = doc.CreateElement("task");
            XmlElement node_id = doc.CreateElement("id");
            node_id.InnerText = Convert.ToString(task.Id);
            XmlElement node_title = doc.CreateElement("title");
            node_title.InnerText = task.Title;
            XmlElement node_content = doc.CreateElement("content");
            node_content.InnerText = task.Content;
            XmlElement node_datetime = doc.CreateElement("datetime");
            node_datetime.InnerText = task.Datetime;
            XmlElement node_state = doc.CreateElement("state");
            node_state.InnerText = task.State;
            node_task.AppendChild(node_id);
            node_task.AppendChild(node_title);
            node_task.AppendChild(node_content);
            node_task.AppendChild(node_datetime);
            node_task.AppendChild(node_state);
            listnode.AppendChild(node_task);
            tasklist.Insert(0,task);
            doc.Save("config/tomato_list.xml");
            txt_title.Text = "";
            txt_content.Text="";
            txt_time.Text="";
            task_list.DataSource = null;
            task_list.DataSource = tasklist;
            //勾选任务列表
            int i = 0;
            foreach (TomatoTask task2 in tasklist)
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
            cfg_tomato_tm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm"));
            cfg_break_tm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/break_tm"));
            cfg_long_break_tm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/long_break_tm"));
            cfg_tomato_cylce = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cylce"));
            //初始化界面
            cycle_count_lb.Text = "循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce;
            tomato_count = Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_count"));
            today_tomato_cnt_lb.Text = "今日:" + GetXmlConfig("config/tomato_user.xml", "/user/tomato_today");
            total_tomato_cnt_lb.Text = "番茄数:" + tomato_count;
            total_cycle_lb.Text = "总循环:" + GetXmlConfig("config/tomato_user.xml", "/user/total_cycle");
            //初始化任务列表
            tasklist = GetXmlConfigList("config/tomato_list.xml", "/list/task");
            task_list.DataSource = tasklist;
            //勾选任务列表
            int i=0;
            foreach (TomatoTask task in tasklist)
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
            
            TomatoList list = new TomatoList();
            list.Id = Convert.ToInt32(tomatosNode.LastChild.SelectSingleNode("id").InnerText) + 1;
            list.Datetime=DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm");
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
            tasklist.Remove(task_list.SelectedValue);
            task_list.DataSource = null;
            task_list.DataSource = tasklist;
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
        }

        private void 首选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tomato_setting == null || tomato_setting.IsDisposed)
            {
                tomato_setting = new Tomato_setting(this);
                tomato_setting.Show();
            }
        }

        /**
         * 窗口置顶
         */ 
        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                isTop = !isTop;
                置顶ToolStripMenuItem.Text = isTop ? "取消置顶" : "置顶";
                this.TopMost = isTop;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tomato_list == null || tomato_list.IsDisposed)
            {
                tomato_list = new Tomato_list(this);
                tomato_list.Show();
            }
        }

        private void task_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id = ((TomatoTask)tasklist[e.Index]).Id;
            XmlDocument doc = new XmlDocument();
            doc.Load("config/tomato_list.xml");
            doc.SelectSingleNode("/list/task[id="+id+"]").SelectSingleNode("state").InnerText=(e.NewValue==CheckState.Checked?"1":"0"); 
            doc.Save("config/tomato_list.xml");
        }

        private void fqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tomato_fq == null || tomato_fq.IsDisposed)
            {
                tomato_fq = new Tomato_fq(this);
                tomato_fq.Show();
            }
            
        }

        

    }
}
