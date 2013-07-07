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
            Assert.That(s.Seasons, Is.Not.Null);
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
            Assert.That(show.Seasons[1].Number, Is.EqualTo(1));
            Assert.That(show.Seasons[1].GetEpisodeByNumber(1).Name, Is.EqualTo("Pilot"));
            Assert.That(show.Seasons[1].GetEpisodeByNumber(1).Number, Is.EqualTo(1));
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
            s.Seasons.Add(s01.Number,s01);

            s.AddSeason(new Season(2));

            s.Seasons[2].Add(new Episode(1, "Second"));

            Assert.That(s.Seasons, Is.Not.Null);
            Assert.That(s.Seasons.Count, Is.EqualTo(2));
            Assert.That(s.Seasons[2].Number, Is.EqualTo(2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = null;

            s.AddSeason(s01);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);

            Season s02 = new Season(1);

            s.AddSeason(s01);
            s.AddSeason(s02);
        }

        [Test]
        public void RemoveSeasonTest()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);
            s.AddSeason(s01);

            s.RemoveSeason(1);
            Assert.That(s.Seasons.Count, Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNotExistingSeasonTest()
        {
            Show s = new Show("Lost");
            s.AddSeason(new Season(1));

            s.RemoveSeason(2);
        }
    }
}
