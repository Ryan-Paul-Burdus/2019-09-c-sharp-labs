select top 5 * from customers order by customerid desc

select * from Products

update Products set UnitsInStock = 200 where ProductID = 31
select * from Products where UnitsInStock < 10 and Discontinued = 0
	order by UnitsInStock desc

--order by
select Country from Customers order by Country 
select distinct Country from Customers order by Country 

--like(contains)
select * from Products where ProductName like '%ch%' -- contains ch
select * from Products where ProductName like 'ch%' --starting with ch
select * from Products where ProductName not like 'ch%' --not starting with ch

--distinct
select distinct region from customers

--in
select * from Customers where Region in ('ak', 'bc', 'ca')

--between
select * from Products where UnitPrice between 10 and 15 order by UnitPrice

--------------------------------------  Task  --------------------------------------------------
--count city, country
select Customers.City, Customers.Country, COUNT(*) as 'count' from Customers 
	group by Customers.City, Customers.Country
select count(distinct city) as 'cities', count(distinct country) as 'countries' from Customers
select count(distinct country) from customers
--average price, min, price, max price
select avg(unitprice) as 'average price', min(unitprice) as 'min price', max(unitprice) as 'max price',
	count(*) as 'count' from products
select min(unitprice) as 'min price' from products
select max(unitprice) as 'max price' from products
--sum of units on stock
select sum(unitsinstock) as 'stock total' from products

select productID, UnitPrice, Discount, (unitprice * (1 - discount)) as 'price with discount' 
	from [Order Details]

select sum(quantity*unitprice) as 'gross sales', 
	sum(quantity*unitprice*(1 - Discount)) as 'discount sales', 
	sum(quantity*unitprice) - sum(quantity*unitprice*(1 - Discount)) as 'gross - discount' 
	from [Order Details]
------------------------------------------------------------------------------------------------

-- group by
select SupplierID, sum(UnitsOnOrder) as 'total units on order' from Products group by SupplierID
	order by 'total units on order' desc

-- having
select SupplierID, sum(UnitsOnOrder) as 'total units on order' from Products group by SupplierID
	having sum(UnitsOnOrder) = 0 order by 'total units on order' desc

--Sub queries
select * from customers where customerID not in (select customerID from orders)