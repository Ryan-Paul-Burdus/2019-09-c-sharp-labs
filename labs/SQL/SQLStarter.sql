use master 
go 

drop database if exists Foods
go

create database Foods
go 

use Foods
	
drop table if exists Fruits
drop table if exists Meats

create table Fruits(
	FruitID int not null IDENTITY PRIMARY KEY,
	FruitName varchar(50) null, 
	FruitType varchar(50) null,
	FruitColor varchar(50) null,
	dateHarvested Date not null
)

create table Meats(
	MeatID int not null IDENTITY PRIMARY KEY,
	AnimalType tinyint null, --0 for cow, 1 for sheep, 2 for pig, 3 for chicken
	MeatName varchar(50) null, 
	MeatColorType BIT null --0 for red, 1 for white
)

create table Batch(
	BatchID int not null IDENTITY PRIMARY KEY, 
	FruitID int null FOREIGN KEY REFERENCES Fruits(FruitID),
	MeatID int null FOREIGN KEY REFERENCES Meats(MeatID),
	Quantity int null, 
	DespatchDate Date null
)

insert into Fruits values('Gala', 'Apple', 'Red', '2019-03-05');
insert into Fruits values('GrannySmith', 'Apple', 'Green', '2019-01-15');
insert into Fruits values('WaterMelon', 'Melon', 'Red', '2019-03-06');

insert into Meats values(2, 'Bacon', 0);
insert into Meats values(3, 'Chicken thigh', 1);
insert into Meats values(3, 'Chicken breast', 1);
insert into Meats values(0, 'Mince beef', 0);

insert into Batch values(1, 1, 24, '2019-06-20');
insert into Batch values(3, 2, 12, '2019-07-04');
insert into Batch values(1, 3, 24, getDate());

select * from Fruits
select * from Meats
select * from Batch

select FruitID, FruitName, BatchID from Fruits