using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Episode
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Episode(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }
    }
}
