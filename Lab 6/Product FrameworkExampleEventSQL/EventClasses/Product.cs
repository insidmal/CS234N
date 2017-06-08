using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToolsCSharp;
using EventPropsClasses;

// *** I had to change this
using ProductDB = EventDBClasses.ProductSQLDB;

// *** I added this
using System.Data;

namespace EventClasses
{
    public class Product : BaseBusiness
    {
        #region props
        public int ID
        {
            get
            {
                return ((ProductProps)mProps).ID;
            }
        }

        public string Description
        {
            get
            {
                return ((ProductProps)mProps).Description;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).Description))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).Description = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Description must be between 1 and 50 characters");
                    }
                }
            }
        }


        public string Code
        {
            get
            {
                return ((ProductProps)mProps).Code;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).Code))
                {
                    if (value.Length >= 1 && value.Length <= 10)
                    {
                        mRules.RuleBroken("Code", false);
                        ((ProductProps)mProps).Code = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Code must be between 1 and 10 characters");
                    }
                }
            }
        }


        public int Quantity
        {
            get
            {
                return ((ProductProps)mProps).Quantity;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).Quantity))
                {
                    if (value >=0)
                    {
                        ((ProductProps)mProps).Quantity = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Quantity must be a positive number.");
                    }
                }
            }
        }



        public decimal Price
        {
            get
            {
                return ((ProductProps)mProps).Price;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).Price))
                {
                    if (value >= 0)
                    {
                        ((ProductProps)mProps).Price = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Price must be a positive number.");
                    }
                }
            }
        }

        #endregion


        #region constructors
        /// <summary>
        /// Default constructor - does nothing.
        /// </summary>
        public Product() : base()
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
        public Product(string cnString)
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
        public Product(int key, string cnString)
            : base(key, cnString)
        {
        }

        public Product(int key)
            : base(key)
        {
        }

        // *** I added these 2 so that I could create a 
        // business object from a properties object
        // I added the new constructors to the base class
        public Product(ProductProps props)
            : base(props)
        {
        }

        public Product(ProductProps props, string cnString)
            : base(props, cnString)
        {
        }
        #endregion


        #region methods

        public override object GetList()
        {
            List<Product> Products = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();


            props = (List<ProductProps>)mdbReadable.RetrieveAll(props.GetType());
            foreach (ProductProps prop in props)
            {
                Product e = new Product(prop, this.mConnectionString);
                Products.Add(e);
            }

            return Products;

        }


        public static List<Product> GetList(string cnString)
        {
            ProductDB db = new ProductDB(cnString);
            List<Product> Products = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();

            // *** methods in the textdb and sqldb classes don't match
            // Ideally, I should go back and fix the IReadDB interface!
            props = (List<ProductProps>)db.RetrieveAll(props.GetType());
            foreach (ProductProps prop in props)
            {
                // *** creates the business object from the props objet
                Product e = new Product(prop, cnString);
                Products.Add(e);
            }

            return Products;
        }


        protected override void SetDefaultProperties()
        {
            //empty class, required by abstract class though defaults are set in props so not needed
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("Code", true);
            mRules.RuleBroken("Description", true);

        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new ProductDB();
                mdbWriteable = new ProductDB();
            }

            else
            {
                mdbReadable = new ProductDB(this.mConnectionString);
                mdbWriteable = new ProductDB(this.mConnectionString);
            }
        }


        public static void Delete(int id)
        {
            ProductDB db = new ProductDB();
            db.Delete(id);
        }

        public static void Delete(int id, string cnString)
        {
            ProductDB db = new ProductDB(cnString);
            db.Delete(id);
        }

        #endregion

    }
}
