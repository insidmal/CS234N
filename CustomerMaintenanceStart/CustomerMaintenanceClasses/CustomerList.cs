using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{

    //page 437
    // test in customertests console
    //there's an existing start file from this so stop here and work from there
    public class CustomerList : IEnumerable<Customer>
    {
        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<Customer>();

        }

        public Customer this[int i] {
            get
            {
                if (i < 0) throw new IndexOutOfRangeException(i.ToString());
                else if (i>this.count) throw new IndexOutOfRangeException(i.ToString());
                return customers[i];
            }
            set
            {
                if (i < 0) throw new IndexOutOfRangeException(i.ToString());
                else if (i > this.count) throw new IndexOutOfRangeException(i.ToString());
                else customers[i] = value;
            }
        }

        public int count
        {
            get { return customers.Count(); }
        }

        public void Add(Customer c)
        {
            customers.Add(c);
        }

        public void Remove(Customer c)
        {
            customers.Remove(c);
        }

        public void Remove(int i)
        {
            customers.RemoveAt(i);
        }

        public static CustomerList operator + (CustomerList cList, Customer c) {
            cList.Add(c);
            return cList;

            }
        
        public static CustomerList operator - (CustomerList cList, Customer c)
        {
            cList.Remove(c);
            return cList;
        }

        public static CustomerList operator -(CustomerList cList, int c)
        {
            cList.Remove(c);
            return cList;
        }

        public static CustomerList Fill()
        {
            CustomerList customers = new CustomerList();
            foreach (Customer customer in CustomerDB.GetCustomers())
            {
                customers.Add(customer);
            }
            return customers;
        }

        public Boolean Save()
        {
            try { CustomerDB.SaveCustomers(customers); return true; }
            catch { return false; }
        }


        public IEnumerator<Customer> GetEnumerator()
        {

            foreach (Customer c in customers)
            {
                yield return c;
            }
        }

     IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
