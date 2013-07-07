using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVLib
{
    public class Show : ICollection<Season>,IEquatable<Show>
    {
        public string Name { get; set; }
        private Dictionary<int,Season> Seasons { get; set; }
        // For IsReadOnly
        private bool isRO = false;

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

        public Season GetSeasonByNumber(int number)
        {
            if (this.Seasons.ContainsKey(number))
            {
                return this.Seasons[number];
            }
            else
            {
                throw  new ArgumentOutOfRangeException("Season nicht vorhanden");
            }
        }

        public bool Remove(int number)
        {
            //Find the Episode to remove
            if (this.Seasons.ContainsKey(number))
            {
                this.Seasons.Remove(number);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ICollection Member

        public void Add(Season item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            else if (!this.Contains(item))
            {
                this.Seasons.Add(item.Number, item);
            }
            else
            {
                throw new ArgumentException("Staffel schon vorhanden");
            }
        }

        public void Clear()
        {
            Seasons.Clear();
        }

        public bool Contains(Season item)
        {
            if (this.Seasons.ContainsKey(item.Number) == true )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTo(Season[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var item in this.Seasons)
            {
                array[i] = (Season)item.Value;
                i++;
            }
        }

        public int Count
        {
            get 
            {
                return Seasons.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return isRO; }
        }

        public bool Remove(Season item)
        {
            //Find the Episode to remove
            if (this.Seasons.ContainsKey(item.Number))
            {
                this.Seasons.Remove(item.Number);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<Season> GetEnumerator()
        {
            foreach (KeyValuePair<int, Season> pair in this.Seasons)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Seasons.GetEnumerator();
        }

        #endregion

        #region IEquatable
        public bool Equals(Show other)
        {
            if (this.Name == other.Name)
            {
                foreach (var thisSeason in this)
                {
                    foreach (var otherSeason in other)
                    {
                        if (otherSeason.Equals(thisSeason))
                        {
                            return true;
                        }
                    }
                }
                //Sonst false
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
