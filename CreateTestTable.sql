CREATE TABLE Employees(
ID INT PRIMARY KEY IDENTITY,
firstname NVARCHAR(50),
lastname NVARCHAR(50),
salary INT
)
GO

INSERT into employees VALUES ('Mark', 'Hasting', 300000)
INSERT into employees VALUES ('Mark2', 'Hasting3', 31000)
INSERT into employees VALUES ('Mark4', 'Hasting', 300)
INSERT into employees VALUES ('Mark32', 'Hasting4', 30003100)