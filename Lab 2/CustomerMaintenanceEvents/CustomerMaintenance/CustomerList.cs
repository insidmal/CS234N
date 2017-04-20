using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    public class CustomerList
	{
		private List<Customer> customers;

        // declare the delegate and then the event here

		public CustomerList()
		{
            customers = new List<Customer>();
		}

		public int Count
		{
			get
			{
				return customers.Count;
			}
		}

		public Customer this[int i]
		{
			get
			{
				return customers[i];
			}
			set
			{
				customers[i] = value;
				//raise the event here
			}
		}

		public void Fill()
		{
			customers = CustomerDB.GetCustomers();
		}

		public void Save()
		{
			CustomerDB.SaveCustomers(customers);
		}

		public void Add(Customer customer)
		{
			customers.Add(customer);
			// raise the event here
		}

		public void Remove(Customer customer)
		{
			customers.Remove(customer);
			// raise the event here
		}

		public static CustomerList operator + (CustomerList c1, Customer c)
		{
			c1.Add(c);
			return c1;
		}

		public static CustomerList operator - (CustomerList c1, Customer c)
		{
			c1.Remove(c);
			return c1;
		}

	}
}
