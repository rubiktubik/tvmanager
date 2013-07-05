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
            s01.AddEpisode(new Episode(1,"Pilot"));
            Dictionary<int, Season> seasons = new Dictionary<int, Season>();

            seasons.Add(s01.Number, s01);

            Show show = new Show("Lost", seasons);

            Assert.That(show.Name, Is.EqualTo("Lost"));
            Assert.That(show.Seasons[1].Number, Is.EqualTo(1));
            Assert.That(show.Seasons[1].Episodes[1].Name, Is.EqualTo("Pilot"));
            Assert.That(show.Seasons[1].Episodes[1].Number, Is.EqualTo(1));
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
        public void AddSeason()
        {
            Show s = new Show("Lost");

            Season s01 = new Season(1);
            s01.AddEpisode(new Episode(1, "Pilot"));

            s.AddSeason(new Season(2));

            s.Seasons[2].AddEpisode(new Episode(1, "Second"));

            Assert.That(s.Seasons, Is.Not.Null);
            Assert.That(s.Seasons.Count, Is.GreaterThan(0));

        }
    }
}
