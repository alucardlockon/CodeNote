using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote
{
    public partial class Tomato_work : Form
    {
        private static Tomato_setting tomato_setting;

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
        //user参数

        public Tomato_work()
        {
            InitializeComponent();
        }

        private void Tomato_work_Load(object sender, EventArgs e)
        {
            time_label.Text = "00:00";
            
            string lists = GetXmlConfigList("config/tomato_list.xml", "/list/task");

            Init();
        }

        

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
                    tomato_count++;
                    if (GetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", "0");
                        SetXmlConfig("config/tomato_user.xml", "/user/tomato_today_date", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_today", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_today")) + 1));
                    SetXmlConfig("config/tomato_user.xml", "/user/tomato_count", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/tomato_count")) + 1));
                    total_tomato_cnt_lb.Text = "番茄数:" + tomato_count;
                    today_tomato_cnt_lb.Text = "今日:" + GetXmlConfig("config/tomato_user.xml", "/user/tomato_today");
                    time_state = "running_break";
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
                        SetXmlConfig("config/tomato_user.xml", "/user/total_cycle", Convert.ToString(Convert.ToInt32(GetXmlConfig("config/tomato_user.xml", "/user/total_cycle")) + 1));
                        total_cycle_lb.Text = "总循环:" + GetXmlConfig("config/tomato_user.xml", "/user/total_cycle");
                    }
                    cycle_count_lb.Text = "循环:" + tomato_now_cylce + "/" + cfg_tomato_cylce;
                    timenow = DateTime.Now;
                    time = DateTime.Now.AddSeconds(cfg_tomato_tm);
                    time_state = "running_tm";
                    now_state_lb.Text = "工作时间";
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
            if (tomato_setting == null || tomato_setting.IsDisposed)
            {
                tomato_setting = new Tomato_setting(this);
                tomato_setting.Show();
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
        }

        private string GetXmlConfigList(string filename,string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return doc.SelectNodes(xpath)[0].InnerText.Trim();
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

    }
}
