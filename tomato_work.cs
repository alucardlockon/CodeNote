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
        private string time_state = "init";
        private DateTime time = new DateTime();
        private DateTime timenow = new DateTime();
        private TimeSpan tmspan=new TimeSpan();
        private long tomato_now_cylce = 0;

        private int cfg_tomato_tm = 1500;
        private int cfg_break_tm = 300;
        private int cfg_tomato_cylce = 4;
        public Tomato_work()
        {
            InitializeComponent();
        }

        private void Tomato_work_Load(object sender, EventArgs e)
        {
            time_label.Text = "00:00";
            string lists = GetXmlConfigList("config/tomato_list.xml", "/list/task");
            cfg_tomato_tm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm"));
            cfg_break_tm = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/break_tm"));
            cfg_tomato_cylce = Convert.ToInt32(GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cycle"));
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
                    time = DateTime.Now.AddMinutes(5);
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
                    time_state="stop";
                    time_label.Text = "00:00";
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
            timer1.Enabled = true;
        }
        /*
         * 暂停 
         */
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            time_state = "pause";
        }
        /*
         * 重新开始 
         */
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            timenow = DateTime.Now;
            time = DateTime.Now.AddSeconds(cfg_tomato_tm);
            time_state = "running_tm";
            timer1.Enabled = true;
        }
        /*
         * 设置 
         */
        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }



        private string GetXmlConfigList(string filename,string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return doc.SelectNodes(xpath)[0].InnerText;
        }

        private string GetXmlConfig(string filename, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return doc.SelectSingleNode(xpath).InnerText;
        }
    }
}
