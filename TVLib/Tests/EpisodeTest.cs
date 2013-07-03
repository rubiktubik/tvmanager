using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
    }
}
