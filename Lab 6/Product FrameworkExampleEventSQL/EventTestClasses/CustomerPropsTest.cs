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
    public class CustomerPropsTest
    {
        CustomerProps cp;
        CustomerProps newCp;


        [SetUp]
        public void CustomerPropsSetup()
        {
            cp = new CustomerProps();
            newCp = new CustomerProps();
            cp.Name = "John Bell";
            cp.Address = "4952 Bluebelle Way";
            cp.City = "Springfield";
            cp.State = "OR";
            cp.Zip = "97478";
            cp.ConcurrencyID = 100;
            
        }

        [Test]
        public void CustomerPropsCloneTest()
        {
            newCp = (CustomerProps)cp.Clone();
            Assert.AreEqual(cp.Address, newCp.Address);
        }

        [Test]
        public void CustomerPropsSerializeTest()
        {
            string xml = cp.GetState();
            Assert.True(xml.Contains("97478"));
        }

        [Test]
        public void CustomerPropsDeseralizeTest()
        {
            string xml = cp.GetState();
            newCp.SetState(xml);
            Assert.AreEqual(cp.Address, newCp.Address);

        }

    }
}
