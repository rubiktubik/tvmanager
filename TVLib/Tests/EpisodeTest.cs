using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;

namespace TVLib
{
    [TestFixture]
    [Category("Episode")]
    public class EpisodeTest
    {
        [Test]
        public void CreateEpisode()
        {
            Episode ep = new Episode(1, "Pilot");
            Assert.IsTrue(ep.Name == "Pilot" && ep.Number == 1);
        }

        [Test]
        public void UpdateEpisode()
        {
            Episode ep = new Episode(1, "Pilot");
            ep.Number = 2;
            ep.Name = "Bla";
            Assert.That(ep.Name, Is.EqualTo("Bla"));
            Assert.That(ep.Number, Is.EqualTo(2));
        }

        [Test]
        public void CompareEpisode()
        {
            ArrayList episodes = new ArrayList();
            Episode ep1 = new Episode(6, "bla");
            Episode ep2 = new Episode(4, "blub");
            Episode ep3 = new Episode(5, "bla");
            Episode ep4 = new Episode(1, "blub");

            episodes.Add(ep1);
            episodes.Add(ep2);
            episodes.Add(ep3);
            episodes.Add(ep4);

            episodes.Sort();

            Episode first = (Episode)episodes[0];
            Episode second = (Episode)episodes[1];
            Episode third = (Episode)episodes[2];
            Episode fourth = (Episode)episodes[3];

            Assert.That(first.Number, Is.EqualTo(1));
            Assert.That(second.Number, Is.EqualTo(4));
            Assert.That(third.Number, Is.EqualTo(5));
            Assert.That(fourth.Number, Is.EqualTo(6));
        }
    }
}
