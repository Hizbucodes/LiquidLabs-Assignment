IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'UserDataDB')
BEGIN
    CREATE DATABASE UserDataDB;
END
GO

USE UserDataDB;
GO


IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    DROP TABLE Users;
END
GO


CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(50),
    Website NVARCHAR(200),
    Street NVARCHAR(200),
    Suite NVARCHAR(100),
    City NVARCHAR(100),
    Zipcode NVARCHAR(20),
    Latitude NVARCHAR(50),
    Longitude NVARCHAR(50),
    CompanyName NVARCHAR(200),
    CatchPhrase NVARCHAR(500),
    BS NVARCHAR(500),
);
GO