using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.domain.tomato
{
    class TomatoUser
    {
        private int tomato_count;
        private int tomato_max;
        private List<Tomato> tomatos;

        public int Tomato_count
        {
            get { return tomato_count; }
            set { tomato_count = value; }
        }

        public int Tomato_max
        {
            get { return tomato_max; }
            set { tomato_max = value; }
        }

        internal List<Tomato> Tomatos
        {
            get { return tomatos; }
            set { tomatos = value; }
        }

    }

    class Tomato{
        private int id;
        private DateTime datetime;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }
    }
}
