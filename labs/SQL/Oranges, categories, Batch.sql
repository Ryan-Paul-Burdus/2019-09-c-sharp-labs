/*put master in scope */
use master 
go 

drop database if exists OrangeDb
go

create database OrangeDb
go

use OrangeDb

drop table if exists Oranges

/* creates sub-relationship table first*/
create table Categories(
	CategoryID int not null IDENTITY PRIMARY KEY,
	CategoryName varchar(50) null
)

create table Oranges(
	OrangeID int not null IDENTITY PRIMARY KEY,
	OrangeName NVARCHAR(50) null,
	DateHarvested Date not null,
	IsLuxuryGrade Bit null,
	OrangeCategoryID int null FOREIGN KEY REFERENCES Categories(CategoryID)

)

create table Batch(
	BatchID int not null IDENTITY PRIMARY KEY, 
	OrangeID int null FOREIGN KEY REFERENCES Oranges(OrangeID),
	Quantity int null, 
	DespatchDate Date null
)

insert into Categories values('clemantines');
insert into Categories values('reds');
insert into Categories values('easy peelers');


insert into Oranges values('Clementine', '2019-09-07', 0, 2);
insert into Oranges values('Blood orange', '2019-09-15', 1, 1);
insert into Oranges values('Tangerine', '2019-09-08', 'false', 3);
insert into Oranges values('Clemantine', '2018-12-25', 0, 1);

insert into Batch values(1, 100, '2019-09-30');
insert into Batch values(2, 100, '2019-09-30');
insert into Batch values(3, 100, getdate());
insert into Batch values(4, 50, '2019-08-01');

select * from Oranges 
select * from Categories

select orangeid, orangename, categoryname from Oranges
inner join categories on oranges.orangecategoryid = categories.categoryid

/* Expiry date = harvested date + 90 days */
select orangeid, orangename, categoryname, dateharvested, dateadd(d, 90,dateharvested) as 'expirydate' from Oranges 
inner join categories on oranges.OrangeCategoryID = Categories.CategoryID

select *, (DATEDIFF(d, DateHarvested, getdate())) as 'SinceHarvested',
case
when (DATEDIFF(d, DateHarvested, getdate())) > 90 then 'true'
else 'false'
end 
as 'IsExpired'
from batch
inner join oranges on oranges.OrangeID = batch.OrangeID

update Categories set CategoryName='red' where CategoryID=2
select * from Categories

insert into Oranges values('Dummy', '2019-09-07', 0, 2);
select * from Oranges
delete from Oranges where OrangeID=5
select * from Oranges