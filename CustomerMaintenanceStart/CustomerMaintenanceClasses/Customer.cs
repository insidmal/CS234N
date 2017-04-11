using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenanceClasses
{
    public class Customer
    {
        private string fName;
        private string lName;
        private string eMail;

        public Customer()
        {

        }

        public Customer(string first, string last, string mail)
        {
            FirstName = first;
            LastName = last;
            Email = mail;
        }

        public string FirstName
        {
            get { return fName; }

            set {
                if (value.Length > 0 && value.Length <= 30)
                    fName = value;
                else throw new ArgumentOutOfRangeException("First Name must be between 1 and 30 characters.");
            }
        }

        public string LastName
        {
            get { return lName; }
            set
            {
                if (value.Length > 0 && value.Length <= 30)
                    lName = value;
                else throw new ArgumentOutOfRangeException("Last Name must be between 1 and 30 characters.");
            }
        }

        public string Email
        {
            get { return eMail; }
            set {
                if (value.Length > 0 && value.Length <= 30 && value.IndexOf("@") != -1)
                    eMail = value;
                else throw new ArgumentOutOfRangeException("Email Address must be between 1 and 30 characters and contain an @ symbol.");
            }
        }

        
        public override string ToString()
        {
            return fName + " " + lName + " (" + eMail + ")";
        }
        
    }

 
}
