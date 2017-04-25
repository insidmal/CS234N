using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMaintenanceClasses
{
    // This application is described in chapter 13 of
    // "Murach's C# 2010" by Joel Murach
    // (c) 2010 by Mike Murach & Associates, Inc. 
    // www.murach.com

    public class ProductList
	{

		private List<Product> products;

		public delegate void ChangeHandler(ProductList products);
		public event ChangeHandler Changed;

		public ProductList()
		{
			products = new List<Product>();
		}

		public int Count
		{
			get
			{
				return products.Count;
			}
		}

		public void Fill()
		{
			products = ProductDB.GetProducts();
		}

		public void Save()
		{
			ProductDB.SaveProducts(products);
		}

		public void Add(Product product)
		{
			products.Add(product);
			Changed(this);
		}

		public void Add(string code, string description, decimal price)
		{
			Product p = new Product(code, description, price);
			products.Add(p);
			Changed(this);
		}

		public void Remove(Product product)
		{
			products.Remove(product);
			Changed(this);
		}

        public override string ToString()
        {
            string output = "";
            foreach (Product p in products)
            {
                output += p.ToString() + "\n";
            }
            return output;
        }

        public Product this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                else if (i >= products.Count)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                return products[i];
            }
            set
            {
                products[i] = value;
                Changed(this);
            }
        }

        public Product this[string code]
        {
            get
            {
                foreach (Product p in products)
                {
                    if (p.Code == code)
                        return p;
                }
                return null;
            }
        }

		public static ProductList operator + (ProductList pl, Product p)
		{
			pl.Add(p);
			return pl;
		}

		public static ProductList operator - (ProductList pl, Product p)
		{
			pl.Remove(p);
			return pl;
		}

	}
}
