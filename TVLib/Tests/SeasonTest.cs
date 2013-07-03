using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TVLib.Tests
{
    [TestFixture]
    [Category("Season")]
    public class SeasonTest
    {
        [Test]
        public void CreateSeasonTest()
        {
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            List<Episode> episoden = new List<Episode>();
            episoden.Add(ep1);
            episoden.Add(ep2);

            Season se = new Season(1, episoden);
            Assert.That(se.Number, Is.EqualTo(1));
            Assert.That(se.Episodes[0].Name, Is.EqualTo("Pilot"));
            Assert.That(se.Episodes[0].Number, Is.EqualTo(1));
            Assert.That(se.Episodes[1].Name, Is.EqualTo("ZweiteFolge"));
            Assert.That(se.Episodes[1].Number, Is.EqualTo(2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNoNullEpisodeList()
        {
            List<Episode> nullListe=null;
            Season se = new Season(1, nullListe);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoEmptyEpisodeList()
        {
            List<Episode> leereListe = new List<Episode>();
            Season se = new Season(1, leereListe);
        }

        [Test]
        public void AddGoodEpisodeTest()
        {
            Episode ep1 = new Episode(1, "Pilot");
            Episode ep2 = new Episode(2, "ZweiteFolge");

            List<Episode> episoden = new List<Episode>();
            episoden.Add(ep1);
            episoden.Add(ep2);

            Season se = new Season(1, episoden);

            se.AddEpisode(new Episode(3,"Dritte Folge"));
            Assert.That(se.Episodes[2].Number, Is.EqualTo(3));
            Assert.That(se.Episodes[2].Name, Is.EqualTo("Dritte Folge"));
        }
    }
}
