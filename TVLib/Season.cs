using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Season : ICollection<Episode>,IEquatable<Season>
    {
        public int Number { get; set; }
        private Dictionary<int, Episode> Episodes { get; set; }

        // For IsReadOnly
        private bool isRO = false;

        public Season(int number)
        {
            this.Number = number;
            this.Episodes = new Dictionary<int, Episode>();
        }

        //Konstruktor
        public Season(int number, Dictionary<int, Episode> episodes)
            : this(number)
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
        public Episode GetEpisodeByNumber(int number)
        {
            if (this.Episodes.ContainsKey(number))
            {
                return Episodes[number];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Episode nicht vorhanden");
            }
        }

        public bool Remove(int number)
        {
            //Find the Episode to remove
            if (this.Episodes.ContainsKey(number))
            {
                this.Episodes.Remove(number);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ICollection Members
        public void Add(Episode item)
        {
            if (!this.Contains(item))
            {
                this.Episodes.Add(item.Number, item);
            }
            else
            {
                throw new ArgumentException("Episode schon vorhanden");
            }
        }

        public void Clear()
        {
            this.Episodes.Clear();
        }

        public bool Contains(Episode item)
        {
            if (this.Episodes.ContainsKey(item.Number) == true && this.Episodes[item.Number].Name == item.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTo(Episode[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var item in this.Episodes)
            {
                array[i] = (Episode)item.Value;
                i++;
            }
        }

        public int Count
        {
            get { return this.Episodes.Count; }
        }

        public bool IsReadOnly
        {
            get { return isRO; }
        }

        public bool Remove(Episode item)
        {
            //Find the Episode to remove
            if (this.Episodes.ContainsKey(item.Number))
            {
                this.Episodes.Remove(item.Number);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<Episode> GetEnumerator()
        {
            foreach (KeyValuePair<int, Episode> pair in this.Episodes)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Episodes.GetEnumerator();
        }
        #endregion

        #region IEqualable Members
        public bool Equals(Season other)
        {
            if (other.Number == this.Number)
            {
                foreach (var otherElement in this)
                {
                    foreach (var thisItem in other)
                    {
                        if (otherElement.Equals(thisItem))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}