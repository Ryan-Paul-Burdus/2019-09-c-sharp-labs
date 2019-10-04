-- 1.1
select * from Customers where City = 'Paris' or City = 'London'

-- 1.2
select * from Products where QuantityPerUnit like '%bottle%'

-- 1.3 
select * from Products inner join Suppliers on Products.SupplierID = Suppliers.SupplierID 
	where QuantityPerUnit like '%bottles%' 

-- 1.4 
select Products.CategoryID, COUNT(*) as 'count' from Products group by Products.CategoryID

-- 1.5
select concat(TitleOfCourtesy, ' ', FirstName, ' ', LastName) as 'Full name', City from Employees where Country = 'UK'

-- 1.6
/*Without discount*/
select RegionDescription, format(sum(UnitPrice * Quantity), 'N0') as 'SalesTotal' from Territories 
	inner join Region on Territories.RegionID = Region.RegionID
	inner join EmployeeTerritories on EmployeeTerritories.TerritoryID = Territories.TerritoryID
	inner join Orders on Orders.EmployeeID = EmployeeTerritories.EmployeeID
	inner join [Order Details] on [Order Details].OrderID = Orders.OrderID 
	group by RegionDescription 
	having sum(UnitPrice * Quantity) > 1000000

/*With discount*/
select RegionDescription, format(sum(UnitPrice * Quantity * (1 - Discount)), 'c', 'en-gb') as 'SalesTotal' from Territories 
	inner join Region on Territories.RegionID = Region.RegionID
	inner join EmployeeTerritories on EmployeeTerritories.TerritoryID = Territories.TerritoryID
	inner join Orders on Orders.EmployeeID = EmployeeTerritories.EmployeeID
	inner join [Order Details] on [Order Details].OrderID = Orders.OrderID 
	group by RegionDescription 
	having sum(UnitPrice * Quantity) > 1000000

-- 1.7 
select count(*) from Orders where Freight > 100.00 and (ShipCountry = 'UK' or ShipCountry = 'USA')  

-- 1.8
select top 1 Orders.OrderID, [Order Details].Discount from Orders inner join [Order Details] on Orders.OrderID = [Order Details].OrderID 
	order by [Order Details].Discount desc 

select top 1 Orders.OrderID, sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) from Orders 
	inner join [Order Details] on Orders.OrderID = [Order Details].OrderID 
	group by Orders.OrderID 
	order by sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) desc 
	
-- 2.1
create table Spartan(
	SpartanID int not null IDENTITY PRIMARY KEY,
	FirstName varchar(50) null,
	LastName varchar(50) null,
	UniversityAttended varchar(50) null,
	CourseTaken varchar(50) null, 
	MarkAchieved int null
)

-- 3.1
SELECT Employees.EmployeeID, CONCAT(Employees.FirstName, ' ', Employees.LastName) AS EmployeeName, CONCAT(Managers.FirstName, ' ', Managers.LastName) AS ReportTo
	FROM Employees
	INNER JOIN Employees AS Managers
	ON Employees.ReportsTo = Managers.EmployeeID

-- 3.2
select Suppliers.SupplierID, Suppliers.CompanyName, round(sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)), 2) as 'unitPrices' 
	from [Order Details]
	inner join Products on [Order Details].ProductID = Products.ProductID
	inner join Suppliers on Products.SupplierID = Suppliers.SupplierID
	group by Suppliers.SupplierID, CompanyName
	having sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) > 10000
	order by sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) asc

-- 3.3
select top 10 Orders.OrderID, convert(varchar, Orders.ShippedDate, 23) as 'Date', Customers.ContactName, 
	format (sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)), 'c')
		as 'Spendings' from Orders 
	inner join Customers on Orders.CustomerID = Customers.CustomerID
	inner join [Order Details] on Orders.OrderID = [Order Details].OrderID
	group by Orders.OrderID, Orders.ShippedDate, Customers.ContactName
	having Orders.ShippedDate between dateadd(year, -1, max(Orders.ShippedDate)) and max(Orders.ShippedDate) 
	order by sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) desc

select top 10 convert(varchar, Orders.ShippedDate, 23) as 'Date', Customers.ContactName, 
	format (sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)), 'c')
		as 'Spendings' from Orders 
	inner join Customers on Orders.CustomerID = Customers.CustomerID
	inner join [Order Details] on Orders.OrderID = [Order Details].OrderID
	group by Orders.ShippedDate, Customers.ContactName
	having Orders.ShippedDate between dateadd(year, -1, max(Orders.ShippedDate)) and max(Orders.ShippedDate) 
	order by sum([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) desc

-- 3.4	
select * from Orders 

