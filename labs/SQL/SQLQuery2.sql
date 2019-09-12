-- 1.1
select * from Customers where City = 'Paris' or City = 'London'

-- 1.2
select * from Products where QuantityPerUnit like '%bottles%'

-- 1.3 - check at work
select * from Products inner join Suppliers on Products.SupplierID = Suppliers.SupplierID 
	where QuantityPerUnit like '%bottles%' 

-- 1.4 - check at work
-- select count(*) from Products inner join Categories on Products.CategoryID = Category.CategoryID 
--	where Products.CategoryID = Category.CategoryID 

-- 1.5 - 
