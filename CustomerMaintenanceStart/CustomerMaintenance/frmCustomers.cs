using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerMaintenanceClasses;

namespace CustomerMaintenance
{
    // This is the starting point for exercise 12-1 from
    // "Murach's C# 2010" by Joel Murach
    // (c) 2010 by Mike Murach & Associates, Inc. 
    // www.murach.com

    public partial class frmCustomers : Form
    {
        CustomerList customers = null;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            Customer c = frm.GetNewCustomer();
            if (c!= null)
            {
                customers+=c;
                customers.Save();
                lstCustomers.Items.Clear();
                frmCustomers_Load(this, null);

            }
                
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerList.Fill();
            for (int i=0; i<customers.count;i++)
                lstCustomers.Items.Add(customers[i]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstCustomers.SelectedIndex>=0) 
            {
                customers -= lstCustomers.SelectedIndex;
                lstCustomers.Items.RemoveAt(lstCustomers.SelectedIndex);
                customers.Save();
            }
        }
    }
}