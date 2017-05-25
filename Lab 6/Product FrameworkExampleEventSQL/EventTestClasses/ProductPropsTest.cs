using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using EventPropsClasses;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductPropsTest
    {
        ProductProps p;
        ProductProps newP;

        [SetUp]
        public void ProductPropSetup()
        {
            p = new ProductProps();
            newP = new ProductProps();

            p.ID = 10;
            p.Code = "P000";
            p.Description = "Test Product";
            p.Price = 100.01m;
            p.Quantity = 1000;
            p.ConcurrencyID = 10000;
        }

        [Test]
        public void ProductPropTestClone()
        {
             newP = (ProductProps)p.Clone();
            Assert.AreEqual(p.Code, newP.Code);
        }

        [Test]
        public void ProductPropTestSerialize()
        {
            string xml = p.GetState();
            Assert.True(xml.Contains("P000"));
        }

        [Test]
        public void ProductPropTestDeserialize()
        {
            string xml = p.GetState();
            newP.SetState(xml);
            Assert.AreEqual(p.Code, newP.Code);
        }

    }
}
