using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.domain.tomato
{
    class TomatoList
    {
        private int id;
        private string datetime;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }
    }

    class TomatoTask
    {
        private int id;
        private string title;
        private string content;
        private string datetime;
        private string state;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public override string ToString()
        {
            string str = "";
            if(datetime!="") str+="["+datetime+"]:";
            if(title!="")  str+="("+title+"):";
            if (content != "") str += content;
            return str;
        }
    }
}
