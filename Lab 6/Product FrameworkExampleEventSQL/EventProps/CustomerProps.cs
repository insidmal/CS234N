using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader;


namespace EventPropsClasses
{
    [Serializable]

    public class CustomerProps : IBaseProps
    {

            #region instance variables
            /// <summary>
            /// Customer ID
            /// </summary>
            public int ID = Int32.MinValue;

            /// <summary>
            /// Customer Name
            /// </summary>
            public String Name = "";

            /// <summary>
            /// Customer Address
            /// </summary>
            public string Address = "";

            /// <summary>
            /// Customer City
            /// </summary>
            public string City = "";

            /// <summary>
            /// Customer State
            /// </summary>
            public string State = "";

            /// <summary>
            /// Customer ZipCode
            /// </summary>
            public string Zip = "";



            /// <summary>
            /// ConcurrencyID. See main docs, don't manipulate directly
            /// </summary>
            public int ConcurrencyID = 0;
            #endregion

            #region constructor
            /// <summary>
            /// Constructor. This object should only be instantiated by Customer, not used directly.
            /// </summary>
            public CustomerProps()
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
                this.ID = (Int32)dr["CustomerID"];
                this.Name = (string)dr["Name"];
                this.Address = (string)dr["Address"];
                this.City = (string)dr["City"];
                this.State = (string)dr["State"];
                this.Zip = (string)dr["ZipCode"];
                this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
            }

            /// <summary>
            /// Sets object properties based on Serialized XML
            /// </summary>
            public void SetState(string xml)
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                StringReader reader = new StringReader(xml);
                CustomerProps p = (CustomerProps)serializer.Deserialize(reader);
                this.ID = p.ID;
                this.Name = p.Name;
                this.Address = p.Address;
                this.City = p.City;
                this.State = p.State;
                this.Zip = p.Zip;
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
                CustomerProps p = new CustomerProps();
                p.ID = this.ID;
                p.Name = this.Name;
                p.Address = this.Address;
                p.City = this.City;
                p.State = this.State;
                p.Zip = this.Zip;
                p.ConcurrencyID = this.ConcurrencyID;
                return p;
            }
            #endregion
        }

    }

