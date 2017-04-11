using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class CustomerList2 : List<Customer>
    {
        public CustomerList2() : base()
        {

        }


        public void Fill()
        {
            //this = CustomerDB.GetCustomers();
        }

        public Boolean Save()
        {
            try { CustomerDB.SaveCustomers(this); return true; }
            catch { return false; }
        }

        public void Add(string fname, string lname, string email)
        {
            Customer c = new CustomerMaintenanceClasses.Customer(fname, lname, email);
            this.Add(c);
        }

        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in this)
                {
                    if (c.Email == email) return c;
                }
                return null;
            }
        }

        public static CustomerList2 operator +(CustomerList2 cList, Customer c)
        {
            cList.Add(c);
            return cList;

        }

        public static CustomerList2 operator -(CustomerList2 cList, Customer c)
        {
            cList.Remove(c);
            return cList;
        }

    }
}
