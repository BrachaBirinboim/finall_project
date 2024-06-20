CREATE TABLE Dietitians (
  id varchar(10)  not null CONSTRAINT Dietitians_pk primary key,
  firstName varchar(50) not null,
  LastName varchar(50) not null,
 email  varchar(25) CHECK (email LIKE '_%@%.%'),
  phone varchar(10) not null
);
CREATE TABLE Clients (
  id varchar(10)  not null CONSTRAINT Clients_pk primary key,
  firstName varchar(50) not null, 
  LastName varchar(50) not null,
  phone varchar(10) not null
);

CREATE TABLE Meetings (
  code int  not null CONSTRAINT Meetings_pk primary key identity (1,1),
  dieticanId varchar(10) CONSTRAINT dieticanId_fk foreign key references Dietitians(id),
  clientsId varchar(10) CONSTRAINT clientsId_fk foreign key references Clients(id),
  Datetime date
);