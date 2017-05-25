using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;


//creates alias for sqldatareader so that it can be changed without changing code
using DBDataReader = System.Data.SqlClient.SqlDataReader;
using System.Data.SqlClient;

namespace EventPropsClasses
{
    [Serializable]
    public class ProductProps : IBaseProps
    {
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
        public int ID = Int32.MinValue;

        /// <summary>
        /// 
        /// </summary>
        public String Code = "";

        /// <summary>
        /// 
        /// </summary>
        public string Description = "";

        /// <summary>
        /// 
        /// </summary>
        public decimal Price=0m;

        /// <summary>
        /// 
        /// </summary>
        public int Quantity = 0;

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int ConcurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor. This object should only be instantiated by Customer, not used directly.
        /// </summary>
        public ProductProps()
        {
        }

        #endregion

        #region BaseProps Members
        /// <summary>
        /// Serializes this props object to XML, and writes the key-value pairs to a string.
        /// </summary>
        /// <returns>String containing key-value pairs</returns>	
        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        /// <summary>
        /// Sets object properties based on db object
        /// </summary>
        /// <param name="dr">database object</param>
        // I don't always want to generate xml in the db class so the 
        // props class can read in from xml
        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["EventID"];
            this.Code = (string)dr["ProductCode"];
            this.Description = (string)dr["Description"];
            this.Price = (decimal)dr["UnitPrice"];
            this.Quantity = (int)dr["OnHandQuantity"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }

        /// <summary>
        /// Sets object properties based on Serialized XML
        /// </summary>
        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringReader reader = new StringReader(xml);
            ProductProps p = (ProductProps)serializer.Deserialize(reader);
            this.ID = p.ID;
            this.Code = p.Code;
            this.Description = p.Description;
            this.Price = p.Price;
            this.Quantity = p.Quantity;
            this.ConcurrencyID = p.ConcurrencyID;
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public Object Clone()
        {
            ProductProps p = new ProductProps();
            p.ID = this.ID;
            p.Code = this.Code;
            p.Description = this.Description;
            p.Price = this.Price;
            p.Quantity = this.Quantity;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }
        #endregion
    }
}
