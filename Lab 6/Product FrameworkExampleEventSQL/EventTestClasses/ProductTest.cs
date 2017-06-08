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
    public class ProductTest
    {

        private string dataSource = "Data Source=DESKTOP-THP73QI\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        ProductSQLDB db;
        ProductProps prod;

        [SetUp]
        public void ProductSQLTestSetUp()
        {
            db = new ProductSQLDB(dataSource);
            prod = new ProductProps();
            //reset databases to original data
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductResets";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void ProductTestConstructorCreate()
        {
            // not in Data Store - no id
            Product p = new Product(dataSource);
            Console.WriteLine(p.ToString());
            Assert.Greater(p.ToString().Length, 1);

        }


        [Test]
        public void ProductTestConstructorDataStore()
        {
            // retrieves from Data Store
            Product p = new Product(1, dataSource);
            Assert.AreEqual(p.ID, 1);
            Assert.AreEqual(p.Code, "A4CS");
            Console.WriteLine(p.ToString());
        }

        [Test]
        public void ProductTestSaveToDataStore()
        {
            Product p = new Product(dataSource);
            p.Code = "T999";
            p.Price = 9001;
            p.Description = "This is the third Product in my Product list.";
            p.Quantity = 9001;
            p.Save();
            Assert.AreEqual(17, p.ID);

            Product p2 = new Product(17,dataSource);
            Assert.AreEqual(p2.Code, p.Code);
        }


        [Test]
        public void ProductTestUpdate()
        {
            Product p = new Product(1, dataSource);
            p.Code = "T876";
            p.Description = "Edited Product";
            p.Price = 90005;
            p.Save();

            p = new Product(1, dataSource);
            Assert.AreEqual(p.Code, "T876");
            Assert.AreEqual(p.Description, "Edited Product");
            Assert.AreEqual(p.Price, 90005);
        }

        [Test]
        public void ProductTestDelete()
        {
            Product p = new Product(3, dataSource);
            p.Delete();
            p.Save();
            Assert.Throws<Exception>(() => new Product(3, dataSource));
        }


        [Test]
        public void ProductTestStaticDelete()
        {
            Product.Delete(2, dataSource);
            Assert.Throws<Exception>(() => new Product(2, dataSource));
        }


        [Test]
        public void ProductTestStaticGetList()
        {
            List<Product> Products = Product.GetList(dataSource);
            Assert.AreEqual(16, Products.Count);
            Assert.AreEqual(1, Products[0].ID);
            Assert.AreEqual("A4CS", Products[0].Code);
        }

        [Test]
        public void ProductTestGetList()
        {
            Product e = new Product(dataSource);
            List<Product> Products = (List<Product>)e.GetList();
            Assert.AreEqual(16, Products.Count);
            Assert.AreEqual(1, Products[0].ID);
            Assert.AreEqual("A4CS", Products[0].Code);
        }

        [Test]
        public void ProductTestNoRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Product e = new Product(dataSource);
            Assert.Throws<Exception>(() => e.Save());
        }


        [Test]
        public void ProductTestSomeRequiredPropertiesNotSet()
        {
            // not in Data Store - userid, title and description must be provided
            Product e = new Product(dataSource);
            Assert.Throws<Exception>(() => e.Save());
            e.Price = 1;
            Assert.Throws<Exception>(() => e.Save());
            e.Description = "this is a test";
            Assert.Throws<Exception>(() => e.Save());
        }


        [Test]
        public void ProductTestInvalidPriceSet()
        {
            Product e = new Product(dataSource);
            Assert.Throws<ArgumentOutOfRangeException>(() => e.Price = -1);
        }


    }
}
