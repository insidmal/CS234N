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
    class BoneYardTests
    {

        BoneYard b1 = new BoneYard(6);
        BoneYard b2 = new BoneYard(0);

        [Test]
        public void TestConstrcutors()
        {
            Assert.IsFalse(b1.IsEmpty());
        }

        [Test]
        public void TestDominsRemaining()
        {
            Assert.AreEqual(28, b1.DominosRemaining);
        }

        [Test]
        public void TestIndexer()
        {
            Assert.AreEqual(0, b1[0].Side1);
        }

        [Test]
        public void TestShuffle()
        {
            b1.Shuffle();
            //it is randomized so may return true on occasion!!
            Assert.AreNotEqual(0, b1[0].Side1);

        }

        [Test]
        public void TestDraw()
        {
            b1.Draw();
            Assert.AreEqual(27, b1.DominosRemaining);
        }

        [Test]
        public void TestDrawException()
        {
            BoneYard by = new BoneYard(2);
            try
            {
                int max = by.DominosRemaining + 10;
                for (int i = 1; i < max; i++)
                {
                    by.Draw();
                }
                Assert.Fail("No Draw Exception");
            }
            catch
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void TestToSTring()
        {
            Assert.AreEqual("Side 1: 0  Side 2: 0\n", b2.ToString());
        }
    }
}
