use master
go

drop database if exists ToDoItemsDatabase
go

create database ToDoItemsDatabase 
go

use ToDoItemsDatabase
go

create table Users(
	UserId int not null identity primary key,
	UserName nvarchar(50) null
);

create table Categories(
	CategoryId int not null identity primary key,
	CategoryName nvarchar(50) null
)

create table ToDoItems(
	ToDoItemId int not null identity primary key, 
	Item varchar(50) null,
	DateDue Date,
	Done bit null,
	UserId int null foreign key references Users(UserId),
	CategoryId int null foreign key references Categories(CategoryId)
);

insert into Users values ('Bob');
insert into Users values ('Bill');
insert into Users values ('Ben');

insert into Categories values ('Admin');
insert into Categories values ('Database');
insert into Categories values ('Coding');

insert into ToDoItems values ('First item', '2019-12-12', 0, 1, 1);
insert into ToDoItems values ('Second item', '2019-11-19', 0, 2, 3);
insert into ToDoItems values ('Third item', '2019-04-22', 1, 3, 1);

select * from Users
select * from Categories
select * from ToDoItems