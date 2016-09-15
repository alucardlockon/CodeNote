using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote
{
    public partial class Tomato_fq : Form
    {
        Tomato_work tomato_work;
        public Tomato_fq(Tomato_work tomato_work)
        {
            InitializeComponent();
            this.tomato_work = tomato_work;
        }

        private void Tomato_fq_Load(object sender, EventArgs e)
        {
            txt_url.Text = GetXmlConfig("config/tomato_url.xml", "/url");
        }

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
        private void SetXmlConfig(string filename, string xpath, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            doc.SelectSingleNode(xpath).InnerText = value.Trim();
            doc.Save(filename);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try { 
                HttpDownloadFile(txt_url.Text, "config/hosts");
                if(!File.Exists("config/hosts_bak")){
                    File.Copy(System.Environment.GetEnvironmentVariable("windir")+@"\System32\drivers\etc\hosts","config/hosts_bak");
                }
                File.Copy("config/hosts",System.Environment.GetEnvironmentVariable("windir")+@"\System32\drivers\etc\hosts",true);
                SetXmlConfig("config/tomato_url.xml", "/url",txt_url.Text);
                RunCmd("ipconfig","/refulshdns");
                MessageBox.Show("操作已完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错:" + ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void btn_recover_Click(object sender, EventArgs e)
        {
            if (!File.Exists("config/hosts_bak"))
            {
                MessageBox.Show("没有需要恢复的文件!");
                return;
            }
            try
            {
                File.Copy("config/hosts_bak",System.Environment.GetEnvironmentVariable("windir") + @"\System32\drivers\etc\hosts",true);
                RunCmd("ipconfig", "/refulshdns");
                MessageBox.Show("文件已恢复");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错:" + ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

        /// <summary>
        /// 运行cmd命令
        /// 不显示命令窗口
        /// </summary>
        /// <param name="cmdExe">指定应用程序的完整路径</param>
        /// <param name="cmdStr">执行命令行参数</param>
        static bool RunCmd(string cmdExe, string cmdStr)
        {
            bool result = false;
            try
            {
                using (Process myPro = new Process())
                {
                    myPro.StartInfo.FileName = "cmd.exe";
                    myPro.StartInfo.UseShellExecute = false;
                    myPro.StartInfo.RedirectStandardInput = true;
                    myPro.StartInfo.RedirectStandardOutput = true;
                    myPro.StartInfo.RedirectStandardError = true;
                    myPro.StartInfo.CreateNoWindow = true;
                    myPro.Start();
                    //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
                    string str = string.Format(@"""{0}"" {1} {2}", cmdExe, cmdStr, "&exit");

                    myPro.StandardInput.WriteLine(str);
                    myPro.StandardInput.AutoFlush = true;
                    myPro.WaitForExit();

                    result = true;
                }
            }
            catch
            {

            }
            return result;
        }

        
    }
}
