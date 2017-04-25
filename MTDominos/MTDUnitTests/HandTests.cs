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
        Hand h2 = null;
        Hand h3 = null;
        Hand h4 = null;

        [SetUp]
        public void HandSetUpTests()
        {
            //we'll see if we need this later, place holder for now
           h2 = new Hand(by, 4);
           h3 = new Hand(by, 6);
            h4 = new Hand(by, 10);
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
            foreach (Domino d in h1)
            {
                h1.RemoveAt(0);
            }
            Assert.AreEqual(0, h1.Count);
            //Assert.IsTrue(h1.IsEmpty);
        }
    }
}
