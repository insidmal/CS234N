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
    public class ProductSQLTest
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
        public void ProductSQLTestRetrieve()
        {

            ProductProps props = (ProductProps)db.Retrieve(1);
            Assert.AreEqual("A4CS", props.Code);
            
        }


        [Test]
        public void ProductSQLTestRetrieveAll()
        {
            List<ProductProps> list = new List<ProductProps>();
            list = (List<ProductProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(16, list.Count);
        }

        [Test]
        public void ProductSQLTestCreate()
        {
            ProductProps p = new ProductProps();
            p.Code = "T999";
            p.Description = "Testin Dis Shiz!";
            p.Quantity = 9001;
            p.Price = 1000000000;

            ProductProps newP = (ProductProps)db.Create(p);
            ProductProps dbP = (ProductProps)db.Retrieve(newP.ID);

            Assert.AreEqual("T999",dbP.Code);
        }

        [Test]
        public void ProductSQLTestUpdate()
        {
            ProductProps p = new ProductProps();
            p.Code = "T999";
            p.Description = "Testin Dis Shiz!";
            p.Quantity = 9001;
            p.Price = 1000000000;

            ProductProps newP = (ProductProps)db.Create(p);
            ProductProps dbP = (ProductProps)db.Retrieve(newP.ID);

            Assert.AreEqual("T999", dbP.Code);
            newP.Code = "T998";
            db.Update(newP);
            dbP = (ProductProps)db.Retrieve(newP.ID);
            Assert.AreEqual("T998", dbP.Code);



        }

        [Test]
        public void ProductSQLTestDelete()
        {
            List<ProductProps> list = new List<ProductProps>();
            list = (List<ProductProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(16, list.Count);
            ProductProps p = new ProductProps();
            p.ID = 1;
            p.ConcurrencyID = 1;

            db.Delete(p);
            list = (List<ProductProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(15, list.Count);


        }

    }
}
