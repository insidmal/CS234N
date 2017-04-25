using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMaintenanceClasses;


namespace ProductTests
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestProductAll();

            //TestProductListConstructor();
            //TestProductListFill();
            //TestProductListAdd();
            //TestProductListRemove();
            //TestProductListIndexers();

            Console.WriteLine();
            Console.ReadLine();
        }

        static void TestProductListConstructor()
        {
            ProductList pList = new ProductList();

            Console.WriteLine("Testing constructor");
            Console.WriteLine("Default constructor.  Expecting count of 0 " + pList.Count);
            Console.WriteLine("Default constructor.  Expecting empty string " + pList);
            Console.WriteLine();
        }

        static void TestProductListFill()
        {
            ProductList pList = new ProductList();
            pList.Fill();

            Console.WriteLine("Testing Fill");
            Console.WriteLine("Expecting count of 5 " + pList.Count);
            Console.WriteLine("Expecting list of 5 products:\n" + pList);
            Console.WriteLine();
        }

        static void TestProductListAdd()
        {
            ProductList pList = new ProductList();
            Product p1 = new Product("T100", "This is a test product", 100M);
            Product p3 = new Product("T300", "Third test product", 300M);

            Console.WriteLine("Testing Add");
            pList.Add(p1);
            Console.WriteLine("Add that takes a product parameter");
            Console.WriteLine("Expecting count of 1 " + pList.Count);
            Console.WriteLine("Expecting list of 1 products:\n" + pList);
            pList.Add("T200", "Second test product", 200M);
            Console.WriteLine("Add that takes individual product attributes and constructs a product");
            Console.WriteLine("Expecting count of 2 " + pList.Count);
            Console.WriteLine("Expecting list of 2 products:\n" + pList);
            pList += p3;
            Console.WriteLine("+ operator");
            Console.WriteLine("Expecting count of 3 " + pList.Count);
            Console.WriteLine("Expecting list of 3 products:\n" + pList);
            Console.WriteLine();
        }

        static void TestProductListRemove()
        {
            ProductList pList = new ProductList();
            Product p1 = new Product("T100", "This is a test product", 100M);
            Product p3 = new Product("T300", "Third test product", 300M);

            pList.Add(p1);
            pList.Add("T200", "Second test product", 200M);
            pList += p3;

            Console.WriteLine("Testing Remove");
            Console.WriteLine("Remove with same object");
            pList.Remove(p1);
            Console.WriteLine("Expecting count of 2 " + pList.Count);
            Console.WriteLine("Expecting list of 2 products.  T100 is not in the list:\n" + pList);
            pList -= p3;
            Console.WriteLine("- operator");
            Console.WriteLine("Expecting count of 1 " + pList.Count);
            Console.WriteLine("Expecting list of 1 products.  T300 is not in the list:\n" + pList);
            Console.WriteLine();
            pList.Remove(new Product("T200", "Second test product", 200M));
            Console.WriteLine("Remove with object that has the same attributes but NOT the same object.\n" +
                "WON'T WORK AT THIS POINT.  CHAPTER 14 will talk about the method Equals.");
            Console.WriteLine("Expecting count of 0 " + pList.Count);
            Console.WriteLine("Expecting list of 0 products.  T200 should not be in the list:\n" + pList);
        }

        static void TestProductListIndexers()
        {
            ProductList pList = new ProductList();
            Product p1 = new Product("T100", "This is a test product", 100M);
            Product p3 = new Product("T300", "Third test product", 300M);

            pList.Add(p1);
            pList.Add("T200", "Second test product", 200M);
            pList += p3;

            Console.WriteLine("Testing indexer");
            Console.WriteLine("Get product with index 0");
            Product p4 = pList[0];
            Console.WriteLine("Expecting T100. " + p4);
            Console.WriteLine("Shouldn't alter the list. Expecting count of 3 " + pList.Count);
            Console.WriteLine("Expecting list of 3 products.  T100 is the first element in list:\n" + pList);

            Console.WriteLine("Get product with code T200");
            Product p5 = pList["T200"];
            Console.WriteLine("Expecting T200. " + p5);
            Console.WriteLine("Shouldn't alter the list. Expecting count of 3 " + pList.Count);
            Console.WriteLine("Expecting list of 3 products.  T200 is the second element in list:\n" + pList);

            Console.WriteLine("Set product with index 0");
            pList[0] = p3;
            Console.WriteLine("Shouldn't alter the length of the list. Expecting count of 3 " + pList.Count);
            Console.WriteLine("Expecting list of 3 products.  T300 is the first element in list as well as the last:\n" + pList);

            // I didn't test the indexer with a number < 0 or > the length of the list, but I should have
            // I didn't test the indexer with a product code that's not in the list, but I should have.
        }

        static void TestProductConstructors()
        {
            Product p1 = new Product();
            Product p2 = new Product("T100", "This is a test product", 100M);

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " + p1.GetDisplayText(", "));
            Console.WriteLine("Overloaded constructor.  Expecting T100, 100, This is a test product. " + p2.GetDisplayText("\t"));
            Console.WriteLine();
        }

        static void TestProductPropertyGetters()
        {
            Product p1 = new Product("T100", "This is a test product", 100M);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Code.  Expecting T100. " + p1.Code);
            Console.WriteLine("Description.  Expecting This is a test product. " + p1.Description);
            Console.WriteLine("Price.  Expecting 100. " + p1.Price);
            Console.WriteLine();
        }

        static void TestProductPropertySetters()
        {
            Product p1 = new Product("T100", "This is a test product", 100M);

            Console.WriteLine("Testing setters");
            p1.Code = "T000";
            p1.Description = "First product";
            p1.Price = 200;
            Console.WriteLine("Expecting T000, 200, First product. " + p1.GetDisplayText(", "));
            Console.WriteLine();
        }

        static void TestProductToString()
        {
            Product p1 = new Product("T100", "This is a test product", 100M);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting T100, 100, This is a test product. " + p1.ToString());
            Console.WriteLine("Expecting T100, 100, This is a test product. " + p1);
            Console.WriteLine();
        }

        static void TestProductAll()
        {
            TestProductConstructors();
            TestProductPropertyGetters();
            TestProductPropertySetters();
            TestProductToString();
            Console.WriteLine();
        }
    }
}
