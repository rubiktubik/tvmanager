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
            if (season == null)
            {
                throw new ArgumentNullException();
            }
            else if (Seasons.ContainsKey(season.Number) == true)
            {
                throw new ArgumentException("Season " + season.Number + " schon vorhanden!");
            }
            else
            {
                this.Seasons.Add(season.Number, season);
            }

        }

        public void RemoveSeason(int number)
        {
            if (this.Seasons.ContainsKey(number) == false)
            {
                throw new ArgumentOutOfRangeException("Keine Season " + number + " vorhanden");
            }
            else
            {
                this.Seasons.Remove(number);
            }
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
