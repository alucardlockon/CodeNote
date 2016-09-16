using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote.tomato
{
    public partial class Tomato_setting : Form
    {

        TomatoWork tomato_work;
        public Tomato_setting(TomatoWork tomato_work)
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
            countdown_color.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/countdown_color");
            countdown_percent.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/countdown_percent");
            miniWnd_color.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_color");
            miniWnd_fontColor.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_fontcolor");
            miniWnd_opacity.Text = GetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_opacity");
        }

        /*
         * 保存
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckParameter())
            {
                return;
            }
            //保存参数
            SetXmlConfig("config/tomato_cfg.xml", "/config/tomato_tm", tomato_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/break_tm", break_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/long_break_tm", long_break_tm.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/tomato_cylce", tomato_cycle.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/countdown_color", countdown_color.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/countdown_percent", countdown_percent.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_color", miniWnd_color.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_fontcolor", miniWnd_fontColor.Text);
            SetXmlConfig("config/tomato_cfg.xml", "/config/miniwnd_opacity", miniWnd_opacity.Text);
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

        private bool CheckParameter()
        {
            string reg=@"^\d*$";
            if (!Regex.IsMatch(tomato_tm.Text.Trim(), reg) || !Regex.IsMatch(break_tm.Text.Trim(), reg) || !Regex.IsMatch(long_break_tm.Text.Trim(), reg) || !Regex.IsMatch(tomato_cycle.Text.Trim(), reg))
            {
                MessageBox.Show("请输入正确的值");
                return false;
            }
            reg = @"^[01]$|^0.\d*$";
            if (!Regex.IsMatch(countdown_percent.Text.Trim(), reg) || !Regex.IsMatch(miniWnd_opacity.Text.Trim(), reg))
            {
                MessageBox.Show("请输入正确的值");
                return false;
            }
            return true;
        }

        private void countdown_color_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            countdown_color.Text=ColorTranslator.ToHtml(colorDialog1.Color);
        }

        private void miniWnd_fontColor_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            miniWnd_fontColor.Text = ColorTranslator.ToHtml(colorDialog1.Color);
        }

        private void miniWnd_color_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            miniWnd_color.Text = ColorTranslator.ToHtml(colorDialog1.Color);
        }

        
    }
}
