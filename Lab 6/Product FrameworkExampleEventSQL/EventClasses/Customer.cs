using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToolsCSharp;
using EventPropsClasses;

// *** I had to change this
using CustomerDB = EventDBClasses.CustomerSQLDB;

// *** I added this
using System.Data;


namespace EventClasses 
{
    public class Customer : BaseBusiness
    {

        #region constructors
        /// <summary>
        /// Default constructor - does nothing.
        /// </summary>
        public Customer() : base()
        {
        }

        /// <summary>
        /// One arg constructor.
        /// Calls methods SetUp(), SetRequiredRules(), 
        /// SetDefaultProperties() and BaseBusiness one arg constructor.
        /// </summary>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Customer(string cnString)
            : base(cnString)
        {
        }

        /// <summary>
        /// Two arg constructor.
        /// Calls methods SetUp() and Load().
        /// </summary>
        /// <param name="key">ID number of a record in the database.
        /// Sent as an arg to Load() to set values of record to properties of an 
        /// object.</param>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Customer(int key, string cnString)
            : base(key, cnString)
        {
        }

        public Customer(int key)
            : base(key)
        {
        }

        // *** I added these 2 so that I could create a 
        // business object from a properties object
        // I added the new constructors to the base class
        public Customer(CustomerProps props)
            : base(props)
        {
        }

        public Customer(CustomerProps props, string cnString)
            : base(props, cnString)
        {
        }
        #endregion


        #region props

        public int ID
        {
            get
            {
                return ((CustomerProps)mProps).ID;
            }
        }

        public string Name
        {
            get
            {
                return ((CustomerProps)mProps).Name;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).Name))
                {
                    if (value.Length >= 5 && value.Length <= 100)
                    {
                        mRules.RuleBroken("Name", false);
                        ((CustomerProps)mProps).Name = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Name must be between 1 and 100 characters");
                    }
                }
            }
        }

        public string Address
        {
            get
            {
                return ((CustomerProps)mProps).Address;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).Address))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Address", false);
                        ((CustomerProps)mProps).Address = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Address must be between 1 and 50 characters");
                    }
                }
            }
        }

        public string City
        {
            get
            {
                return ((CustomerProps)mProps).City;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).City))
                {
                    if (value.Length >= 1 && value.Length <= 20)
                    {
                        mRules.RuleBroken("City", false);
                        ((CustomerProps)mProps).City = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("City must be between 1 and 20 characters");
                    }
                }
            }
        }

        public string State
        {
            get
            {
                return ((CustomerProps)mProps).State;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).State))
                {
                    if (value.Length == 2)
                    {
                        mRules.RuleBroken("State", false);
                        ((CustomerProps)mProps).State = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("State must be 2 characters");
                    }
                }
            }
        }


        public string Zip
        {
            get
            {
                return ((CustomerProps)mProps).Zip.Trim();
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).Zip))
                {
                    if (value.Length >= 1 && value.Length <= 15)
                    {
                        mRules.RuleBroken("Zip", false);
                        ((CustomerProps)mProps).Zip = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Zip Code must be between 1 and 15 characters");
                    }
                }
            }
        }
        #endregion


        public override object GetList()
        {
            List<Customer> Customers = new List<Customer>();
            List<CustomerProps> props = new List<CustomerProps>();


            props = (List<CustomerProps>)mdbReadable.RetrieveAll(props.GetType());
            foreach (CustomerProps prop in props)
            {
                Customer e = new Customer(prop, this.mConnectionString);
                Customers.Add(e);
            }

            return Customers;
        }

        public static List<Customer> GetList(string cnString)
        {
            CustomerDB db = new CustomerDB(cnString);
            List<Customer> Customers = new List<Customer>();
            List<CustomerProps> props = new List<CustomerProps>();

            // *** methods in the textdb and sqldb classes don't match
            // Ideally, I should go back and fix the IReadDB interface!
            props = (List<CustomerProps>)db.RetrieveAll(props.GetType());
            foreach (CustomerProps prop in props)
            {
                // *** creates the business object from the props objet
                Customer e = new Customer(prop, cnString);
                Customers.Add(e);
            }

            return Customers;
        }

        public static void Delete(int id, string cnString)
        {
            CustomerDB db = new CustomerDB(cnString);
            db.Delete(id);
        }

        protected override void SetDefaultProperties()
        {
            //empty class, required by abstract class though defaults are set in props so not needed
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("Address", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
            mRules.RuleBroken("Zip", true);
        }

        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new CustomerDB();
                mdbWriteable = new CustomerDB();
            }

            else
            {
                mdbReadable = new CustomerDB(this.mConnectionString);
                mdbWriteable = new CustomerDB(this.mConnectionString);
            }
        }
    }
}
