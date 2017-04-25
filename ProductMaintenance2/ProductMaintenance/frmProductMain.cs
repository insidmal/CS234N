using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductMaintenanceClasses;

namespace ProductMaintenance

{
    // This application is described in chapter 13 of
    // "Murach's C# 2010" by Joel Murach
    // (c) 2010 by Mike Murach & Associates, Inc. 
    // www.murach.com
    
    public partial class frmProductMain : Form
	{
		public frmProductMain()
		{
			InitializeComponent();
		}

		private ProductList products = new ProductList();

		private void frmProductMain_Load(object sender, System.EventArgs e)
		{
			products.Changed += new ProductList.ChangeHandler(HandleChange);
			products.Fill();
			FillProductListBox();
		}

		private void FillProductListBox()
		{
			Product p;
			lstProducts.Items.Clear();
			for (int i = 0; i < products.Count; i++)
			{
				p = products[i];
				lstProducts.Items.Add(p.GetDisplayText("\t"));
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			frmNewProduct newForm = new frmNewProduct();
			Product product = newForm.GetNewProduct();
			if (product != null)
			{
				products += product;
                products.Save();
                FillProductListBox();
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			int i = lstProducts.SelectedIndex;
			if (i != -1)
			{
				Product product = products[i];
				string message = "Are you sure you want to delete "
					+ product.Description + "?";
				DialogResult button = MessageBox.Show(message, "Confirm Delete",
					MessageBoxButtons.YesNo);
				if (button == DialogResult.Yes)
				{
					products -= product;
                    products.Save();
                    FillProductListBox();
				}
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        
		private void HandleChange(ProductList products)
		{
			products.Save();
			FillProductListBox();
		}
        
	}
}