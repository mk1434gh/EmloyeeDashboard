CREATE DATABASE EmployeeDashboard
Go

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserName NVARCHAR(100) UNIQUE NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);
GO

INSERT INTO Roles (RoleName) VALUES ('Admin'), ('User');
GO

INSERT INTO Users (UserName, Email, PasswordHash, RoleId)
VALUES 
('admin', 'admin@example.com', 'admin@123', 1),
('clerk', 'user@example.com', 'user@123', 2);
GO

INSERT INTO Employees (Name) VALUES ('Mahesh Babu'), ('Paul Smith'), ('Rohith Shetty'), ('Harsh Remji'), ('Nishanth Koudhik');
GO
