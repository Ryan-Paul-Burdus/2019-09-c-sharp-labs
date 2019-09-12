use master
go

drop database if exists RabbitDb
go

create database RabbitDb
go

use RabbitDb 
go

CREATE TABLE Rabbits(
	RabbitId INT NOT NULL IDENTITY PRIMARY KEY,	
	Age INT NULL, 
	Name VARCHAR(50) NULL
);

INSERT INTO Rabbits VALUES ('1' , 'Rabbit01')	
INSERT INTO Rabbits VALUES ('7' , 'Rabbit02')	
INSERT INTO Rabbits VALUES ('2' , 'Rabbit03')	
INSERT INTO Rabbits VALUES ('4' , 'Rabbit04')	

--UPDATE Rabbits Set Name='Dead rabbit' WHERE RabbitId=2

SELECT * FROM Rabbits

