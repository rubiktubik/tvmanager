using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Season
    {
        public int Number { get; set; }
        public Dictionary<int,Episode> Episodes { get; set; }

        public Season(int number) 
        {
            this.Number = number;
            this.Episodes = new Dictionary<int, Episode>();
        }

        //Konstruktor
        public Season(int number, Dictionary<int, Episode> episodes) : this(number)
        {
            //Auf Null pruefen
            if (episodes == null)
            {
                throw new ArgumentNullException();
            }
            else if (episodes.Count <= 0)
            {
                throw new ArgumentException("Keine Liste mit 0 Elementen erlaubt!");
            }
            else
            {
                this.Episodes = episodes;
            }
        }


        public void AddEpisode(Episode episode)
        {
            this.Episodes.Add(episode.Number, episode);
        }

        /// <summary>
        /// Remove Episode 
        /// </summary>
        /// <param name="number">Episodenumber which is used as key</param>
        public void RemoveEpisode(int number)
        {
            this.Episodes.Remove(number);
        }
    }
}
