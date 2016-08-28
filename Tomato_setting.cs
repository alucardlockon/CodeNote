using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote
{
    public partial class Tomato_setting : Form
    {
        Tomato_work tomato_work;
        public Tomato_setting(Tomato_work tomato_work)
        {
            InitializeComponent();
            this.tomato_work = tomato_work;
        }

        private void Tomato_setting_Load(object sender, EventArgs e)
        {
            //初始化界面参数
            tomato_tm.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm");
            break_tm.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/break_tm");
            long_break_tm.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/long_break_tm");
            tomato_cycle.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cylce");

        }

        /*
         * 保存
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //保存参数
            SetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm", tomato_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/break_tm", break_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/long_break_tm", long_break_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cylce", tomato_cycle.Text);
            if (tomato_work != null) { 
                tomato_work.Init();
            }
            this.Close();
        }

        /*
         * 取消
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetXmlConfig(string filename, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return doc.SelectSingleNode(xpath).InnerText.Trim();
        }

        private void SetXmlConfig(string filename, string xpath,string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            doc.SelectSingleNode(xpath).InnerText = value.Trim();
            doc.Save(filename);
        }

        
    }
}
