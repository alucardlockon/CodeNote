using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace CodeNote.tomato
{
    public partial class TomatoList : Form
    {
        TomatoWork _tomatoWork;
        public TomatoList(TomatoWork tomatoWork)
        {
            InitializeComponent();
            this._tomatoWork = tomatoWork;
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
