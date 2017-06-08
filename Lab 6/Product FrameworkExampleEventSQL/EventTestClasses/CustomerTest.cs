using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using EventClasses;
using EventPropsClasses;
using EventDBClasses;
using ToolsCSharp;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using System.Data;
using System.Data.SqlClient;

using DBCommand = System.Data.SqlClient.SqlCommand;


namespace EventTestClasses
{
    [TestFixture]
    public class CustomerTest
    {

        private string dataSource = "Data Source=DESKTOP-THP73QI\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        CustomerSQLDB db;
        CustomerProps prod;

        [SetUp]
        public void CustomerSQLTestSetUp()
        {
            db = new CustomerSQLDB(dataSource);
            prod = new CustomerProps();
            //reset databases to original data
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductResets";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void CustomerTestConstructorCreate()
        {
            // not in Data Store - no id
            Customer p = new Customer(dataSource);
            Console.WriteLine(p.ToString());
            Assert.Greater(p.ToString().Length, 1);

        }


        [Test]
        public void CustomerTestConstructorDataStore()
        {
            // retrieves from Data Store
            Customer p = new Customer(1, dataSource);
            Assert.AreEqual(p.ID, 1);
            Assert.AreEqual(p.Address, "1108 Johanna Bay Drive");
            Console.WriteLine(p.ToString());
        }

        [Test]
        public void CustomerTestSaveToDataStore()
        {
            Customer p = new Customer(dataSource);
            p.Name = "Republic";
            p.State = "OR";
            p.City = "Alpha Romero";
            p.Address = "Banana";
            p.Zip = "90005";
            p.Save();
            Assert.AreEqual(700, p.ID);

            Customer p2 = new Customer(700, dataSource);
            Assert.AreEqual(p2.Name, p.Name);
        }


        [Test]
        public void CustomerTestUpdate()
        {
            Customer p = new Customer(1, dataSource);
            p.Name = "Republic, B";
           
            p.Address = "Banana";
            p.Zip = "90005";
            p.Save();

            p = new Customer(1, dataSource);
            Assert.AreEqual(p.Address, "Banana");
            Assert.AreEqual(p.Zip, "90005");
            Assert.AreEqual(p.Name, "Republic, B");
        }

        [Test]
        public void CustomerTestDelete()
        {
            Customer p = new Customer(3, dataSource);
            p.Delete();
            p.Save();
            Assert.Throws<Exception>(() => new Customer(3, dataSource));
        }


        [Test]
        public void CustomerTestStaticDelete()
        {
            Customer.Delete(2, dataSource);
            Assert.Throws<Exception>(() => new Customer(2, dataSource));
        }


        [Test]
        public void CustomerTestStaticGetList()
        {
            List<Customer> Customers = Customer.GetList(dataSource);
            Assert.AreEqual(696, Customers.Count);
            Assert.AreEqual("Molunguri, A", Customers[0].Name);
            Assert.AreEqual("1108 Johanna Bay Drive", Customers[0].Address);
        }

        [Test]
        public void CustomerTestGetList()
        {
            Customer e = new Customer(dataSource);
            List<Customer> Customers = (List<Customer>)e.GetList();
            Assert.AreEqual(696, Customers.Count);
            Assert.AreEqual("Molunguri, A", Customers[0].Name);
            Assert.AreEqual("1108 Johanna Bay Drive", Customers[0].Address);
        }

        [Test]
        public void CustomerTestNoRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Customer e = new Customer(dataSource);
            Assert.Throws<Exception>(() => e.Save());
        }


        [Test]
        public void CustomerTestSomeRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Customer e = new Customer(dataSource);
            Assert.Throws<Exception>(() => e.Save());
            e.Name = "customer name";
            Assert.Throws<Exception>(() => e.Save());
            e.Address = "this is a test";
            Assert.Throws<Exception>(() => e.Save());
        }


        [Test]
        public void CustomerTestInvalidNameSet()
        {
            Customer e = new Customer(dataSource);
            Assert.Throws<ArgumentException>(() => e.Name = "a");
        }


    }
}
