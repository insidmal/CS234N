using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class RetailCustomer : Customer
    {
        private string phone;

        public RetailCustomer() { }

        public RetailCustomer(string first, string last, string email, string phone) : base(first, last, email)
        {
            Phone = phone;
        }

        public string Phone
        {
            get { return phone;  }
            set { phone = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " " + phone;
        }

    }



}
