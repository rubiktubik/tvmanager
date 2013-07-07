using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TVLib.Tests
{
    [TestFixture]
    [Category("season")]
    public class SeasonTest
    {
        [Test]
        public void CreateSeasonWithoutListTest()
        {
            Season s = new Season(1);
            Assert.That(s.Count, Is.EqualTo(0));
            Assert.That(s.Number, Is.EqualTo(1));
        }

        [Test]
        public void CreateSeasonTest()
        {
            //Zwei Folgen erstellt
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            //Liste von Folgen
            Dictionary<int, Episode> episoden = new Dictionary<int, Episode>();

            //Folgen zur Liste hinzugefügt
            episoden.Add(ep1.Number, ep1);
            episoden.Add(ep2.Number, ep2);
            //Neue Season mit der Folgenliste erstellen
            Season se = new Season(1, episoden);
            
            Assert.That(se.Number, Is.EqualTo(1));

            Assert.That(se.GetEpisodeByNumber(1).Number, Is.EqualTo(1));
            Assert.That(se.GetEpisodeByNumber(2).Number, Is.EqualTo(2));
            Assert.That(se.GetEpisodeByNumber(1).Name, Is.EqualTo("Pilot"));
            Assert.That(se.GetEpisodeByNumber(2).Name, Is.EqualTo("ZweiteFolge"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNoNullEpisodeList()
        {
            Dictionary<int,Episode> nullListe=null;
            Season se = new Season(1, nullListe);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoEmptyEpisodeList()
        {
            Dictionary<int, Episode> leereListe = new Dictionary<int, Episode>();
            Season se = new Season(1, leereListe);
        }

        [Test]
        public void AddGoodEpisodeTest()
        {
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            Dictionary<int, Episode> episoden = new Dictionary<int, Episode>();
            episoden.Add(ep1.Number,ep1);
            episoden.Add(ep2.Number,ep2);

            Season se = new Season(1, episoden);

            se.Add(new Episode(3,"Dritte Folge"));
            Assert.That(se.GetEpisodeByNumber(3).Number, Is.EqualTo(3));
            Assert.That(se.GetEpisodeByNumber(3).Name, Is.EqualTo("Dritte Folge"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDoubleEpisodeTest()
        {
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            Dictionary<int, Episode> episoden = new Dictionary<int, Episode>();
            episoden.Add(ep1.Number, ep1);
            episoden.Add(ep2.Number, ep2);

            Season se = new Season(1, episoden);

            se.Add(new Episode(2, "Dritte Folge"));
        }

        [Test]
        public void GetEpisodeGoodTest()
        {
            Season s01 = new Season(1);
            

            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));

            Episode first = s01.GetEpisodeByNumber(1);
            Episode second = s01.GetEpisodeByNumber(2);

            Assert.That(first.Number, Is.EqualTo(1));
            Assert.That(first.Name, Is.EqualTo("Pilot"));
            Assert.That(second.Number, Is.EqualTo(2));
            Assert.That(second.Name, Is.EqualTo("Second"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetNonExistingEpisodeTest()
        {
            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            //Get not existing Episode
            Episode ep = s01.GetEpisodeByNumber(2);
        }

        [Test]
        public void ContainsTest()
        {
            Season s01 = new Season(1);

            s01.Add(new Episode(1, "Pilot"));

            Episode ep1 = new Episode(1,"Pilot");

            Assert.That(s01.Contains(ep1));
        }

        [Test]
        public void ClearCountTest()
        {
            Season s01 = new Season(1);

            s01.Add(new Episode(1, "Pilot"));
            Assert.That(s01.Count, Is.EqualTo(1));
            s01.Clear();
            Assert.That(s01.Count, Is.EqualTo(0));
        }


        [Test]
        public void CopyToTest()
        {
            Season s01 = new Season(1);

            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));
            s01.Add(new Episode(3, "Third"));

            Episode[] liste = new Episode[s01.Count];

            s01.CopyTo(liste, 0);

            Assert.That(liste[0].Name, Is.EqualTo("Pilot"));
            Assert.That(liste[1].Name, Is.EqualTo("Second"));
            Assert.That(liste[2].Name, Is.EqualTo("Third"));
        }

        [Test]
        public void EqualsTrueTest()
        {
            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));

            Season s02 = new Season(1);
            s02.Add(new Episode(1, "Pilot"));
            s02.Add(new Episode(2, "Second"));

            Assert.That(s01.Equals(s02));
        }

        [Test]
        public void EqualsFalseTest()
        {
            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));

            Season s02 = new Season(1);
            s02.Add(new Episode(1, "Pilot"));
            s02.Add(new Episode(2, "Bla"));

            Assert.That(s02.Equals(s01));
        }

    }
}
