using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    class PrivateTrainTests
    {

        Hand h1;
        Hand h2;
        PrivateTrain pt1;
        PrivateTrain pt2;
        Domino d1;
        Domino d2;

        [SetUp]
        public void PTSetup()
        {
            h1 = new Hand();
            h2 = new Hand();
            d1 = new Domino(6, 6);
            d2 = new Domino(1, 1);
            pt1 = new PrivateTrain(h1);
            pt2 = new PrivateTrain(h2, 6);
            pt2.Open();
        }

        [Test]
        public void PTtestOpen()
        {
            pt1.Open();
            Assert.IsTrue(pt1.IsOpen);
        }

        [Test]
        public void PTtestClose()
        {
            pt2.Close();
            Assert.IsFalse(pt2.IsOpen);
        }

        [Test]
        public void PTtestIsPlayable()
        {
            bool mustFlip;
            Assert.IsTrue(pt1.IsPlayable(d1, out mustFlip));
            Assert.IsFalse(pt2.IsPlayable(d2, out mustFlip, h1));
        }

        [Test]
        public void PTtestPlay()
        {
            pt1.Play(d1);
            Assert.AreEqual(6, pt1.PlayableValue);
        }


    }
}
