ALTER TABLE Dietitians
ADD kind varchar(255);


ALTER TABLE Dietitians
ADD CONSTRAINT check_kind
  CHECK (kind IN ('ז', 'נ'));

ALTER TABLE Clients
ADD kind char

ALTER TABLE Clients
ADD CONSTRAINT check_kind1
  CHECK (kind IN ('m', 'f'));
ALTER TABLE Clients
ADD BirthDate DateTime

ALTER TABLE Meetings
Add [status] nvarchar(255) 



ALTER TABLE Meetings
  drop COLUMN [Datetime]
  
  
ALTER TABLE Meetings
  add  [date]  datetime

  ALTER TABLE Meetings
  add  [hour]  datetime

