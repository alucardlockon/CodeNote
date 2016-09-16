using CodeNote.domain.tomato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote.tomato
{
    public partial class Tomato_listDetail : Form
    {
        private TomatoTask _NowTask;
        private TomatoWork _tomatoWork;
        public Tomato_listDetail(TomatoWork tomatoWork,string id)
        {
            InitializeComponent();
            _NowTask = GetTaskList("config/tomato_list.xml", "/list/task[id=" + id + "]");
            base.Text = _NowTask.Title;
            this._tomatoWork = tomatoWork;

            txt_datetime.Text = _NowTask.Datetime;
            txt_title.Text=_NowTask.Title;
            txt_content.Text = _NowTask.Content;
            //处理子列表
            ch_showList.Checked = _tomatoWork.CfgShowDetailList;
            txt_sublist.Text = _NowTask.Sublist;
            ReloadSubList();
            
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            TomatoTask task=new TomatoTask();
            task.Id = _NowTask.Id;
            task.Datetime = txt_datetime.Text;
            task.Title = txt_title.Text;
            task.Content = txt_content.Text;
            task.State = _NowTask.State;
            ReloadSubList();
            task.Sublist = _NowTask.Sublist;
            SetTaskList("config/tomato_list.xml", "/list/task[id=" + _NowTask.Id + "]",task);
            _tomatoWork.ReloadList();
            
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ReloadSubList()
        {
            if (ch_showList.Checked)
            {
                _NowTask.Sublist = txt_sublist.Text;
                string subliststring = "";
                foreach (string a in _NowTask.Sublist.Split("\r\n".ToCharArray()))
                {
                    if (a.Length > 0)
                    {
                        if (!a.StartsWith("(o)") && !a.StartsWith("(x)"))
                        {
                            subliststring += "(x)" + a + "\r\n";
                        }
                        else
                        {
                            subliststring += a + "\r\n";
                        }
                    }
                }
                txt_sublist.Text = subliststring;
                _NowTask.Sublist = subliststring;
            }
            else
            {
                _NowTask.Sublist = txt_sublist.Text;
                txt_sublist.Text = _NowTask.Sublist.Replace("(o)", "").Replace("(x)", "");
            }
        }

        private TomatoTask GetTaskList(string filename, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode node = doc.SelectSingleNode(xpath);
            TomatoTask task = new TomatoTask();
            if (node != null)
            {
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
            }
            return task;
        }

        private void SetTaskList(string filename, string xpath,TomatoTask task)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode node = doc.SelectSingleNode(xpath);
            if (node != null)
            {
                var n1 = node.SelectSingleNode("id");
                if (n1 != null)
                    n1.InnerText = task.Id.ToString().Trim();
                else
                {
                    XmlElement ele=doc.CreateElement("id");
                    ele.InnerText = task.Id.ToString().Trim();
                    node.AppendChild(ele);
                }
                var n2 = node.SelectSingleNode("title");
                if (n2 != null)
                    n2.InnerText=task.Title.Trim();
                else{
                    XmlElement ele = doc.CreateElement("title");
                    ele.InnerText = task.Title.ToString().Trim();
                    node.AppendChild(ele);
                }
                var n3 = node.SelectSingleNode("content");
                if (n3 != null)
                    n3.InnerText=task.Content.Trim();
                else
                {
                    XmlElement ele = doc.CreateElement("content");
                    ele.InnerText = task.Content.ToString().Trim();
                    node.AppendChild(ele);
                }
                var n4 = node.SelectSingleNode("datetime");
                if (n4 != null)
                    n4.InnerText=task.Datetime.Trim();
                else
                {
                    XmlElement ele = doc.CreateElement("datetime");
                    ele.InnerText = task.Datetime.ToString().Trim();
                    node.AppendChild(ele);
                }
                var n5 = node.SelectSingleNode("state");
                if (n5 != null)
                    n5.InnerText=task.State.Trim();
                else
                {
                    XmlElement ele = doc.CreateElement("state");
                    ele.InnerText = task.State.ToString().Trim();
                    node.AppendChild(ele);
                }
                var n6 = node.SelectSingleNode("sublist");
                if (n6 != null)
                    n6.InnerText = task.Sublist.Trim();
                else
                {
                    XmlElement ele = doc.CreateElement("sublist");
                    ele.InnerText = task.Sublist.ToString().Trim();
                    node.AppendChild(ele);
                }
            }
            doc.Save(filename);
        }

        private void ch_showList_CheckedChanged(object sender, EventArgs e)
        {
            _tomatoWork.CfgShowDetailList = ch_showList.Checked;
            SetXmlConfig("config/tomato_cfg.xml", "/config/show_detail_list", ch_showList.Checked.ToString());
            ReloadSubList();
        }

        

        private void SetXmlConfig(string filename, string xpath, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var n1 = doc.SelectSingleNode(xpath);
            if (n1 != null) n1.InnerText = value.Trim();
            doc.Save(filename);
        }
        
    }
}
