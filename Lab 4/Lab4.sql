/****** Select Statements for Lab 4  ******/
-- 1.  Select all of the customers who live in NY state
select * from customers where State='NY'
-- 2.  Select all of the states that start with A 
 select StateName from States where StateName like 'A%'
-- 3.  Select all of the Products that have a price between 50 and 60 dollars
 select * from Products where UnitPrice between 50 and 60
-- 4.  Show me the value of the inventory that we have on hand for each product
select *, UnitPrice*OnHandQuantity as OnHandValue from Products where OnHandQuantity>0
-- 5.  Get me a list of the invoices in April, May or June
select *,  Month(InvoiceDate) as Month from Invoices where Month(InvoiceDate) in(4,5,6)
-- 6.  Get me a list of the invoices in Jan or April

select *,  Month(InvoiceDate) as Month from Invoices where Month(InvoiceDate) in(1,4)

-- 7.  Add the name of the state to the result set from #1
select * from customers inner join States on customers.State = States.StateCode where State='NY'
-- 8.  Add the customer's name to the result set from #5
select *,  Month(InvoiceDate) as Month from Invoices inner join Customers on invoices.CustomerID=Customers.CustomerID where Month(InvoiceDate) in(4,5,6)

-- 9.  Get me a list of all of the products that have been ordered.  Include the quantity ordered on each invoice.

select * from InvoiceLineItems inner join Products on InvoiceLineItems.ProductCode = Products.ProductCode

-- 10. Get me a list of all of the invoices.  Include all of the items ordered on the invoice, including the detailed information about each product.
--     You'll have more than one record for each invoice.


select * from Invoices inner join InvoiceLineItems on Invoices.InvoiceID=InvoiceLineItems.InvoiceID inner join Products on InvoiceLineItems.ProductCode = Products.ProductCode

-- 11. Add the customer's name and address to the results from 10.
select * from Customers inner join Invoices on Customers.CustomerID = Invoices.CustomerID inner join InvoiceLineItems on Invoices.InvoiceID=InvoiceLineItems.InvoiceID inner join Products on InvoiceLineItems.ProductCode = Products.ProductCode

-- 12. Add the name of the state to the results from 11.
select * from Customers inner join States on Customers.State = States.StateCode inner join Invoices on Customers.CustomerID = Invoices.CustomerID inner join InvoiceLineItems on Invoices.InvoiceID=InvoiceLineItems.InvoiceID inner join Products on InvoiceLineItems.ProductCode = Products.ProductCode


-- 13. How many products do we have?
select count(*) from Products

-- 14. What's the total value of all of the products sold?
Select sum(UnitPrice) from InvoiceLineItems
-- 15. What's the total value of all of the inventory we have on hand?
Select Sum(OnHandquantity*UnitPrice) from Products
-- 16. How many orders has each customer placed?  EXTRA CREDIT:  List all customers, even if they don't have any orders.
Select count(Invoices.CustomerID) as TotalOrder from Invoices inner join Customers on Invoices.CustomerID = Customers.CustomerID group by Customers.CustomerID