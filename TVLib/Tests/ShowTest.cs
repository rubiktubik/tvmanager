using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TVLib.Tests
{
    [TestFixture]
    [Category("Show")]
    public class ShowTest
    {
        [Test]
        public void CreateShowWithoutListTest()
        {
            Show s = new Show("Lost");
            Assert.That(s.Count, Is.EqualTo(0));
            Assert.That(s.Name, Is.EqualTo("Lost"));
        }

        [Test]
        public void CreateShowWitListTest()
        {
            Season s01 = new Season(1);
            s01.Add(new Episode(1,"Pilot"));
            Dictionary<int, Season> seasons = new Dictionary<int, Season>();

            seasons.Add(s01.Number, s01);

            Show show = new Show("Lost", seasons);

            Assert.That(show.Name, Is.EqualTo("Lost"));
            Assert.That(show.GetSeasonByNumber(1).Number, Is.EqualTo(1));
            Assert.That(show.GetSeasonByNumber(1).GetEpisodeByNumber(1).Name, Is.EqualTo("Pilot"));
            Assert.That(show.GetSeasonByNumber(1).GetEpisodeByNumber(1).Number, Is.EqualTo(1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNoNullSeasonList()
        {
            Dictionary<int, Season> nullListe = null;
            Show se = new Show("Lost", nullListe);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoEmptySeasonList()
        {
            Dictionary<int, Season> leereListe = new Dictionary<int, Season>();
            Show se = new Show("Lost", leereListe);
        }

        [Test]
        public void AddSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            s.Add(s01);

            s.Add(new Season(2));

            s.GetSeasonByNumber(2).Add(new Episode(1, "Second"));

            Assert.That(s.Count, Is.Not.EqualTo(0));
            Assert.That(s.Count, Is.EqualTo(2));
            Assert.That(s.GetSeasonByNumber(2).Number, Is.EqualTo(2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = null;

            s.Add(s01);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);

            Season s02 = new Season(1);

            s.Add(s01);
            s.Add(s02);
        }

        [Test]
        public void RemoveSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);
            s.Add(s01);

            s.Remove(s01);
            Assert.That(s.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveNotExistingSeasonTest()
        {
            Show s = new Show("Lost");
            s.Add(new Season(1));

            Season s02 = new Season(2);

            Assert.That(!s.Remove(s02));
        }

        [Test]
        public void ContainsShowTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);

            s01.Add(new Episode(1, "Pilot"));

            s.Add(s01);

            Assert.That(s.Contains(s01),Is.True);
        }

        [Test]
        public void ClearCountTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);

            s01.Add(new Episode(1, "Pilot"));

            s.Add(s01);

            Assert.That(s.Count, Is.EqualTo(1));

            s.Clear();

            Assert.That(s.Count, Is.EqualTo(0));
        }


        [Test]
        public void CopyToTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);
            Season s02 = new Season(2);

            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));
            s01.Add(new Episode(3, "Third"));

            s.Add(s01);
            s.Add(s02);

            Season[] liste = new Season[s.Count];

            s.CopyTo(liste, 0);

            Assert.That(liste[0].Number, Is.EqualTo(1));
            Assert.That(liste[0].GetEpisodeByNumber(3).Name, Is.EqualTo("Third"));
            Assert.That(liste[1].Number, Is.EqualTo(2));
        }

        [Test]
        public void EqualsTrueTest()
        {
            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));

            Season s02 = new Season(2);
            s02.Add(new Episode(1, "Pilot"));
            s02.Add(new Episode(2, "Second"));

            Show show1 = new Show("Lost");
            show1.Add(s01);
            show1.Add(s02);

            Show show2 = new Show("Lost");
            show2.Add(s01);
            show2.Add(s02);

            Assert.That(show1.Equals(show2));
        }

        [Test]
        public void EqualsFalseTest()
        {
            //TODO: Geht noch nicht
            Season s01 = new Season(1);
            s01.Add(new Episode(1, "Pilot"));
            s01.Add(new Episode(2, "Second"));

            Season s02 = new Season(2);
            s02.Add(new Episode(1, "Pilot"));
            s02.Add(new Episode(2, "BLa"));

            Show show1 = new Show("Lost");
            show1.Add(s01);
            show1.Add(s02);

            Show show2 = new Show("Lost");
            show2.Add(s01);
            show2.Add(s02);

            Assert.That(show1.Equals(show2),Is.False);
        }
    }
}
