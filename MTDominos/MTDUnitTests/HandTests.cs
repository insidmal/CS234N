using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTDClasses;
using NUnit.Framework;

namespace MTDUnitTests
{

    [TestFixture]
    class HandTests
    {

        Hand h1 = new Hand();
        BoneYard by = new BoneYard(12);
        BoneYard by2 = new BoneYard(12);

        Hand h2 = null;
        Hand h3 = null;
        Hand h4 = null;
        Hand h5 = null;
        Hand h6 = null;
        Hand h7 = null;
        Domino d1 = new Domino(1, 1);
        Domino d2 = new Domino(4, 3);
        Domino d3 = new Domino(7, 7);
        Domino d4 = new Domino(2, 8);

        [SetUp]
        public void HandSetUpTests()
        {
            //used h1, h2, 3, 5, 6
           h2 = new Hand(by, 4);
           h3 = new Hand(by, 6);
            h4 = new Hand(by, 10);
            h5 = new Hand(by2, 4);
            h6 = new Hand(by2, 4);
            h7 = new Hand(by2, 4);

            //just emptying h5 and h6 for a later test
            for (int i = 0; i < 15; i++)
            {
                h5.RemoveAt(0);
                h6.RemoveAt(0);
                h7.RemoveAt(0);
            }
            //making h6 have a specific domino so we can know the expected results
            h6.Add(d1);
            //same for h7
            h7.Add(d1);
            h7.Add(d2);
            h7.Add(d3);
            h7.Add(d4); 

        }

        [Test]
        public void HandTestConstructorsAndCount()
        {
            Assert.AreEqual(15, h1.Count);
            Assert.AreEqual(15, h2.Count);
            Assert.AreEqual(12, h3.Count);
            Assert.AreEqual(10, h4.Count);
        }
    
        [Test]
        public void HandTestIsEmpty()
        {
            for(int i=0; i<15;i++)
            {
                h1.RemoveAt(0);
            }
            Assert.AreEqual(0, h1.Count);
        }

        [Test]
        public void HandTestScore()
        {

            Assert.AreEqual(2, h6.Score);
            //test empty hand
            Assert.AreEqual(0, h5.Score);
        }

        [Test]
        public void HandTestIndexer()
        {

            Assert.AreEqual("Side 1: 1  Side 2: 1", h6[0].ToString());
        }

        [Test]
        public void HandTestAdd()
        {
            //added in setup and tested in Score but going to test here also
            Assert.AreEqual(1, h6.Count);
        }

        [Test]
        public void HandDrawTest()
        {
            h3.Draw(by);
            Assert.AreEqual(13, h3.Count);
        }

        [Test]
        public void HandTestIndexOfDomino()
        {
            Assert.AreEqual(0, h6.IndexOfDomino(1));
        }

        [Test]
        public void TestHasDomino()
        {
            //actually going to test with a domino we don't have, this will let me test the opposite return of indexofdomino

            Assert.IsFalse(h6.HasDomino(2));
        }

        [Test]
        public void HandTestIndexOfDouble()
        {
            Assert.AreEqual(0, h6.IndexOfDoubleDomino(1));
        }

        [Test]
        public void HandTestIndexOFHighDub()
        {
            Assert.AreEqual(2, h7.IndexOfHighDouble());
        }

        [Test]
        public void HandTestHasDouble()
        {
            //doing one we don't have to test the neg output of index;
            Assert.IsFalse(h5.HasDoubleDomino(5));

        }

        [Test]
        public void HandTestGet()
        {
            Assert.AreEqual("Side 1: 1  Side 2: 1", h5.GetDomino(1).ToString());
        }

        [Test]
        public void HandTestGetDouble()
        {
            Assert.AreEqual("Side 1: 1  Side 2: 1", h5.GetDomino(1).ToString());
        }
        //this still needs to be finished

        //don't forget to do get domino or whatever
    }
}
