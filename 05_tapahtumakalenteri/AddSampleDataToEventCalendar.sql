use EventCalendar
GO

INSERT INTO Categories (Name, Description)
VALUES ('Meeting', 'Meetings with colleagues, clients, or partners'),
       ('Conference', 'Conferences or large gatherings'),
       ('Workshop', 'Training workshops and educational sessions'),
       ('Social', 'Social events and gatherings'),
       ('Webinar', 'Online presentations and seminars');
GO

-- Sample data for Users
DECLARE @i INT = 1;
WHILE @i <= 20
BEGIN
    INSERT INTO Users (FirstName, LastName, Email, PasswordHash, Role)
    VALUES ('User' + CAST(@i AS NVARCHAR), 'Lastname', 'user' + CAST(@i AS NVARCHAR) + '@example.com', 'hashedpassword' + CAST(@i AS NVARCHAR), 'User');
    SET @i = @i + 1;
END
GO

-- Sample data for Events
DECLARE @j INT = 1;
WHILE @j <= 20
BEGIN
    INSERT INTO Events (Title, Description, StartDate, EndDate, Location, CategoryId, CreatedBy)
    VALUES ('Event ' + CAST(@j AS NVARCHAR), 'Description for Event ' + CAST(@j AS NVARCHAR), DATEADD(DAY, @j * 3, GETDATE()), DATEADD(DAY, @j * 3, DATEADD(HOUR, 2, GETDATE())), 'Location ' + CAST(@j AS NVARCHAR), 1 + (@j % 5), 1 + (@j % 20));
    SET @j = @j + 1;
END
GO
