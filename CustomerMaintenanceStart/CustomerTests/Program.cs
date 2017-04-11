using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerMaintenanceClasses;

namespace CustomerTests
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestCustomerConstructors();
            //TestCustomerGetters();
            //TestCustomerSetters();

            //TestCustomerFNameEx();

            //TestcustomerValidators();

            //TestWholesaleCustomer();
            TestRetailCustomer();


            Console.WriteLine();
            Console.ReadLine();
        }

        //this one is new
        static void TestRetailCustomer()
        {
            RetailCustomer rc = new RetailCustomer("john", "bell", "contact@conquest-marketing.com", "(541) 579-6627");

            Console.WriteLine("Testing Retail Customer");
            Console.WriteLine("Expecting john bell contact@conquest-marketing.com (541) 579-6627");
             Console.WriteLine(rc);
            Console.WriteLine("Testing Property, Setting Phone Number to (541) 968-0452");
            rc.Phone = "(541) 968-0452";
            Console.WriteLine("Expecting just the new phone number: " + rc.Phone);

        }

        static void TestWholesaleCustomer()
        {
            WholesaleCustomer wc = new WholesaleCustomer("john", "bell", "contact@conquest-marketing.com", "Conquest Marketing");
            Console.WriteLine("Testing WholeSale Constructor");
            Console.WriteLine("Expecting john bell contact@conquest-marketing.com works for Conquest Marketing");
            Console.WriteLine(wc);
            Console.WriteLine("Changing Company property to Banana Haven");
            wc.Company = "Banana Haven";
            Console.WriteLine("Outputting Company property, expecting Banana Haven: " + wc.Company);
        }

        static void TestcustomerValidators()
        {
            Customer c1 = new Customer();

            Console.WriteLine("Testing First Name");
            Console.WriteLine("Too long, expecting exception");
            try { c1.FirstName = "kljakjldsjkfdslkjfdsajlkkjlfdsakjlfdslkjsfdalkjsafdlkjdsfkjskfdjlalfds"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Too short, expecting exception");
            try { c1.FirstName = ""; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Valid, next line should return firstname value of John");
            try { c1.FirstName = "John"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine(c1.FirstName.ToString());

            Console.WriteLine();
            Console.WriteLine("Testing Last Name");
            Console.WriteLine("Too long, expecting exception");
            try { c1.LastName = "kljakjldsjkfdslkjfdsajlkkjlfdsakjlfdslkjsfdalkjsafdlkjdsfkjskfdjlalfds"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Too short, expecting exception");
            try { c1.LastName = ""; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Valid, next line should return lastname value of Bell");
            try { c1.LastName = "Bell"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine(c1.LastName.ToString());

            Console.WriteLine();
            Console.WriteLine("Testing Email Name");
            Console.WriteLine("Too long, expecting exception");
            try { c1.Email = "kljakjldsjkfdslkjfdsajlkkjlfdsakjlfdslkjsfdalkjsafdlkjdsfkjskfdjlalfds"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Too short, expecting exception");
            try { c1.Email = ""; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("No @, expecting exception");
            try { c1.Email = "emailaddress"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Valid, next line should return email value of contact@conquest-marketing.com");
            try { c1.Email = "contact@conquest-marketing.com"; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine(c1.Email);

        }

        static void TestCustomerConstructors()
        {
            Customer c1 = new Customer();
            Customer c2 = new Customer("John", "Bell", "john@conquest-marketing.com");

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " + c1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting John Bell (john@conquest-marketing.com)" + c2.ToString());
            Console.WriteLine();
        }

        static void TestCustomerGetters()
        {
            Customer c1 = new Customer();
            Customer c2 = new Customer("John", "Bell", "john@conquest-marketing.com");

            Console.WriteLine("Testing Get Accessors -- Default");
            Console.WriteLine("Testing firstname, expecting default: " + c1.FirstName);
            Console.WriteLine("Testing lastname, expecting default: " + c1.LastName);
            Console.WriteLine("Testing email, expecting default: " + c1.Email);
            Console.WriteLine();


            Console.WriteLine("Testing Get Accessors -- with values");
            Console.WriteLine("Testing firstname, expecting John: " + c2.FirstName);
            Console.WriteLine("Testing lastname, expecting Bell: " + c2.LastName);
            Console.WriteLine("Testing email, expecting contact@conquest-marketing.com: " + c2.Email);
            Console.WriteLine();
        }

        static void TestCustomerSetters()
        {
            //I know I could just output one line but I wanted to be able to test each set accessor individually and get their result as I go
            Customer c2 = new Customer("John", "Bell", "john@conquest-marketing.com");

            Console.WriteLine("Testing Get Accessors -- with values");
            Console.WriteLine("Testing firstname, expecting John: " + c2.FirstName);
            Console.WriteLine("setting firstname to Mickey");
            c2.FirstName = "Mickey";
            Console.WriteLine("Testing firstname, expecting Mickey: " + c2.FirstName);
            Console.WriteLine();

            Console.WriteLine("Testing lastname, expecting Bell: " + c2.LastName);
            Console.WriteLine("setting last name to mouse");
            c2.LastName = "Mouse";
            Console.WriteLine("Testing lastname, expecting mouse: " + c2.LastName);
            Console.WriteLine();

            Console.WriteLine("Testing email, expecting contact@conquest-marketing.com: " + c2.Email);
            Console.WriteLine("setting email to mmouse@disney.com");
            c2.Email = "mmouse@disney.com";
            Console.WriteLine("Testing email, expecting mmouse@disney.com: " + c2.Email);
            Console.WriteLine();

        }

        static void TestCustomerFNameEx()
        {
            Customer c2 = new Customer("John", "Bell", "john@conquest-marketing.com");
            try
            {
                Console.WriteLine("testing short name");
                c2.FirstName = "";
                Console.WriteLine("It didn't work :(");
            }
            catch (Exception es)
            {
                Console.WriteLine("Input Boken! Test Worked!");
                Console.WriteLine(es);
            }

            // test long name
            try
            {
                Console.WriteLine("testing long name");
                c2.FirstName = "kjadsfhjasdfjhaijsdfkhasjkdfhkjahsdkjlfhakjlsdfhlkjasdljhaskdljfhlkajsdfkljhasdkljfhlkjasdljkhasdjkfhakljsdfadskjfhakjsdf";
                Console.WriteLine("It didn't work :(");
            }
            catch (Exception es)
            {
                Console.WriteLine("Input Boken! Test Worked!");
                Console.WriteLine(es);
            }

        }

    }


    }
