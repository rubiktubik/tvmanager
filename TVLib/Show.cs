using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Show
    {
        public string Name { get; set; }
        public Dictionary<int,Season> Seasons { get; set; }

        /// <summary>
        /// Adds a new season to the Show
        /// </summary>
        public void AddSeason(Season season)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSeason(int number)
        {
            throw new System.NotImplementedException();
        }

        public Show(string name, Dictionary<int, Season> seasons) : this(name)
        {
            if (seasons == null)
            {
                throw new ArgumentNullException();
            }
            else if (seasons.Count <= 0)
            {
                throw new ArgumentException("Keine Liste mit 0 Elementen erlaubt!");
            }
            else
            {
                this.Seasons = seasons;
            }
        }

        public Show(string name)
        {
            this.Name = name;
            this.Seasons = new Dictionary<int, Season>();
        }
    }
}
