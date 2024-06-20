INSERT INTO Clients (id, firstName, LastName, phone, kind, BirthDate)
VALUES (328974215, 'John', 'Doe', '1234567890', 'm', '1990-01-01'),
       (219687453, 'Jane', 'Doe', '0987654321', 'f', '1995-05-05');
INSERT INTO Dietitians (id, firstName, LastName, email, phone, kind)
VALUES (329874515, 'David', 'Smith', 'david@example.com', '1234567890', 'm'),
       (326978451, 'Sarah', 'Johnson', 'sarah@example.com', '0987654321', 'f');
INSERT INTO Meetings (dieticanId, clientId, status, date, hour)
VALUES (329874515, 328974215, 'existed', '2023-12-01', '12:00:00'),
       (326978451, 219687453, 'existed', '2023-12-02', '14:30:00');
INSERT INTO WorkHours (dayInTheWeek, dieticanId, startHour, endHour)
VALUES (1, 329874515, '08:00:00', '16:00:00'),
       (2, 326978451, '09:00:00', '17:00:00');
ALTER TABLE Meetings
ADD CONSTRAINT meeting CHECK (status IN ('invited', 'existed', 'canceled'));


