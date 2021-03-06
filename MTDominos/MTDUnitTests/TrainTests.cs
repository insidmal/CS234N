﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    class TrainTests
    {

        Train t1 = new Train(6);
        Train t2 = new Train(6);
        Train t3 = new Train(6);
        Train t4 = new Train(6);


        Domino d61 = new Domino(6, 1);
        Domino d13 = new Domino(1, 3);
        Domino d53 = new Domino(5, 3);

        [SetUp]
        public void TestSetup()
        {
            t4.Play(d61);

        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.AreEqual(true, t1.IsEmpty);
        }

        [Test]
        public void TestEmptyLastDomino()
        {
            Assert.AreEqual("Side 1: 6  Side 2: 6", t1.LastDomino.ToString());

        }

        [Test]
        public void TestPlayableValue()
        {
            Assert.AreEqual(6, t1.PlayableValue);
        }

        [Test]
        public void TestIsPlayable()
        {
            bool flip;
            //should be playable and not need to be flipped
            Assert.AreEqual(true, t1.IsPlayable(d61, out flip));
            Assert.IsFalse(flip);
        }

        [Test]
        public void TestPlay()
        {
            t2.Play(d61);
            Assert.AreEqual(1, t2.PlayableValue);
        }

        [Test]
        public void TestAdd()
        {
            t3.Add(d61);
            Assert.AreEqual(1, t3.PlayableValue);
        }

        [Test]
        public void TestLastDomino()
        {
            Assert.AreEqual("Side 1: 1  Side 2: 6", t4.LastDomino.ToString());
        }

        [Test]
        public void TestIndexer()
        {
            Assert.AreEqual("Side 1: 6  Side 2: 1", t4[0].ToString());
        }

        [Test]
        public void TestGetEnginveValue()
        {
            Assert.AreEqual(6, t1.EngineValue);
        }

        [Test]
        public void TestSetEnginveValue()
        {
            t4.EngineValue = 2;
            Assert.AreEqual(2, t4.EngineValue);
        }
        //GETS FOR ALL
        //EngineValue + SET

        [Test]
        public void TestPlaying()
        {
            Domino d1 = new Domino(1, 2);
            Train t1 = new Train(1);

            try
            {
                int i = t1.PlayableValue;
                Assert.Fail("PlayableValue should be exception");
            }
            catch {
                Assert.Pass();
            }

            Assert.AreEqual(0, t1.Count);
            t1.Play(d1);
            Assert.AreEqual(2, t1.PlayableValue);
            Assert.AreEqual(1, t1.Count);

        }


        //Design an nUnit unit test that ensures that playing a Domino 
        //that contains the PlayableValue for a
        //(Mexican or Public) Train can be played AND that the 
        //PlayableValue and Count are updated appropriately.



    }
}
