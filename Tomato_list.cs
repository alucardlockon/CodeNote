using System;
using System.Collections;
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
    public partial class Tomato_list : Form
    {
        Tomato_work tomato_work;
        public Tomato_list(Tomato_work tomato_work)
        {
            InitializeComponent();
            this.tomato_work = tomato_work;
        }

        private void Tomato_list_Load(object sender, EventArgs e)
        {
            BindList("config/tomato_user.xml", "/user/tomatos");
        }

        private void BindList(string filename, string xpath)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodeList = doc.SelectSingleNode(xpath).SelectNodes("tomato");
            var items = new List<ListViewItem>();
            foreach (XmlNode node in nodeList)
            {
                var viewItem = new ListViewItem();
                viewItem.Text = "第"+node.SelectSingleNode("id").InnerText + "个番茄，在" + node.SelectSingleNode("datetime").InnerText+"完成!";
                items.Add(viewItem);
            }
            ListViewItem[] arr=items.ToArray();
            Array.Reverse(arr);
            lv_his.Items.AddRange(arr);
        }

    }
}
