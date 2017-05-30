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
           
        }

        [Test]
        public void ProductSQLTestRetrieve()
        {

            ProductProps props = (ProductProps)db.Retrieve(1);
            Assert.AreEqual("A4CS", props.Code);
            
        }

    }
}
