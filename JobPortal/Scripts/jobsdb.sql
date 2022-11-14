Create database Jobs
go


use Jobs

CREATE TABLE tblLocation(
LocationID  int IDENTITY(1,1) PRIMARY KEY,
Title varchar(50) not null,
City varchar(50) not null,
State varchar(50) not null ,
Country varchar(50) not null ,
Zip varchar(5) not null ,


);

CREATE TABLE tblDepartments(
DepartmentID  int IDENTITY(1,1) PRIMARY KEY,
Department varchar(50) not null ,

); 

CREATE TABLE tblJobs(
JobID  int IDENTITY(1,1) PRIMARY KEY,
Title varchar(50) not null,
Description varchar(100) ,
Code varchar(100) ,
DepartmentID int FOREIGN KEY REFERENCES tblDepartments(DepartmentID)not null,
LocationID int FOREIGN KEY REFERENCES tblLocation(LocationID) not null,

PostedDate smalldatetime not null,
ClosingDate smalldatetime not null
);

INSERT INTO tblLocation values ('US Head Office', 'MD', 'New York', 'United States','12456')
INSERT INTO tblLocation values ('Panjim Head Office', 'Panjim', 'Goa', 'India','12456')

INSERT INTO tblDepartments values( 'Software Developer' )
INSERT INTO tblDepartments values( 'Digital Marketing')





