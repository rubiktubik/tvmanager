using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Episode : IComparable,IEquatable<Episode>
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Episode(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Episode otherEpisode = obj as Episode;
            return this.Number.CompareTo(otherEpisode.Number);
        }

        public bool Equals(Episode other)
        {
            if (this.Name == other.Name && this.Number == this.Number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
