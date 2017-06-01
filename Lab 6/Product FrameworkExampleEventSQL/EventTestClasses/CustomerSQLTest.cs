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
    //RUN THESE TESTS!!!
    [TestFixture]
    public class CustomerSQLTest
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
        public void CustomerSQLTestRetrieve()
        {

            CustomerProps props = (CustomerProps)db.Retrieve(1);
            Assert.AreEqual("Molunguri, A", props.Name);

        }


        [Test]
        public void CustomerSQLTestRetrieveAll()
        {
            List<CustomerProps> list = new List<CustomerProps>();
            list = (List<CustomerProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(696, list.Count);
        }

        [Test]
        public void CustomerSQLTestCreate()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "J Dub";
            p.Address = "420 West 13th Ave";
            p.City = "Eugene";
            p.State = "OR";
            p.Zip = "97402";

            CustomerProps newC = (CustomerProps)db.Create(p);
            CustomerProps dbP = (CustomerProps)db.Retrieve(newC.ID);

            Assert.AreEqual("J Dub", dbP.Name);
        }

        [Test]
        public void CustomerSQLTestUpdate()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "J Dub";
            p.Address = "420 West 13th Ave";
            p.City = "Eugene";
            p.State = "OR";
            p.Zip = "97402";

            CustomerProps newP = (CustomerProps)db.Create(p);
            CustomerProps dbP = (CustomerProps)db.Retrieve(newP.ID);

            Assert.AreEqual("J Dub", dbP.Name);
            newP.Name = "J Dubbizle";
            db.Update(newP);
            dbP = (CustomerProps)db.Retrieve(newP.ID);
            Assert.AreEqual("J Dubbizle", dbP.Name);
        }

        [Test]
        public void CustomerSQLTestDelete()
        {
            List<CustomerProps> list = new List<CustomerProps>();
            list = (List<CustomerProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(696, list.Count);
            CustomerProps p = new CustomerProps();
            p.ID = 1;
            p.ConcurrencyID = 1;

            db.Delete(p);
            list = (List<CustomerProps>)db.RetrieveAll(list.GetType());
            Assert.AreEqual(695, list.Count);


        }


    }
}
