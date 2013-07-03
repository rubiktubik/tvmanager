using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Season
    {
        public int Number { get; set; }
        public List<Episode> Episodes { get; set; }

        public void AddEpisode(Episode episode)
        {
            this.Episodes.Add(episode);
            //TODO: Keine doppelten Folgen!
        }

        public void RemoveEpisode(int number)
        {
            throw new System.NotImplementedException();
            //TODO: Besser Struktur für Episodenliste um besser zu suchen und loeschen
        }

        //Konstruktor
        public Season(int number, List<Episode> episodes)
        {
            this.Number = number;
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
    }
}
