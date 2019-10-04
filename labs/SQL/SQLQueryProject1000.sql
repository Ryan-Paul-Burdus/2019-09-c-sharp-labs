use master 
go 

drop database if exists ShopDb
go

create database ShopDb
go

use ShopDb
go

create table Categories(
	CategoryId INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(50) NULL
);

create table Items(
	ItemId int IDENTITY PRIMARY KEY NOT NULL,
	ItemName varchar(50) NULL, 
	ItemPrice float NULL,
	CategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
);

create table Customers(
	CustomerId INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName varchar(50) NULL, 
	LastName varchar(50) NULL 

);

create table Orders(
	OrderId int IDENTITY PRIMARY KEY NOT NULL,
	ItemQuantity int NULL,
	OrderPrice float NULL,
	CustomerId INT NULL FOREIGN KEY REFERENCES Customers(CustomerId)
);


insert into Categories values ('Vegetable');
insert into Categories values ('Fruit');
insert into Categories values ('Meat');
insert into Categories values ('Drink');
insert into Categories values ('Snack');

insert into Items values ('Apple', 0.5, 2);
insert into Items values ('Potato', 0.75, 1);
insert into Items values ('Beef', 3.0, 3);

insert into Customers values ('John', 'Smith');
insert into Customers values ('Steve', 'Rogers');
insert into Customers values ('Dave', 'Sparkles');

insert into Orders values (32, 56.50, 2);
insert into Orders values (4, 10.00, 3);


select * from Items;
select * from Categories;
select * from Customers;
select * from Orders;