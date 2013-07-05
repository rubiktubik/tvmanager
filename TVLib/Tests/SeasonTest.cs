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
            Assert.That(s.Episodes, Is.Not.Null);
            Assert.That(s.Number, Is.EqualTo(1));
        }

        [Test]
        public void CreateSeasonTest()
        {
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            Dictionary<int, Episode> episoden = new Dictionary<int, Episode>();

            episoden.Add(ep1.Number, ep1);
            episoden.Add(ep2.Number, ep2);
            Season se = new Season(1, episoden);
            
            Assert.That(se.Number, Is.EqualTo(1));

            Assert.That(se.Episodes[1].Number, Is.EqualTo(1));
            Assert.That(se.Episodes[2].Number, Is.EqualTo(2));
            Assert.That(se.Episodes[1].Name, Is.EqualTo("Pilot"));
            Assert.That(se.Episodes[2].Name, Is.EqualTo("ZweiteFolge"));
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

            se.AddEpisode(new Episode(3,"Dritte Folge"));
            Assert.That(se.Episodes[3].Number, Is.EqualTo(3));
            Assert.That(se.Episodes[3].Name, Is.EqualTo("Dritte Folge"));
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

            se.AddEpisode(new Episode(2, "Dritte Folge"));
        }
    }
}
