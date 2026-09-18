USE master;
GO
IF DB_ID(N'TestDB') IS NOT NULL
BEGIN
ALTER DATABASE TestDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE TestDB;
END
GO
CREATE DATABASE TestDB;
GO
USE TestDB;
GO

-- ===== BANG USERS =====
CREATE TABLE Users (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(50)   NOT NULL UNIQUE,
    Email        NVARCHAR(100)  NOT NULL,
    PasswordHash NVARCHAR(255)  NOT NULL,
    Role         NVARCHAR(20)   NOT NULL DEFAULT N'user',
    CreatedAt    DATETIME2      NOT NULL DEFAULT SYSDATETIME()
);
GO

-- ===== BANG PRODUCTS =====
CREATE TABLE Products (
    Id        INT IDENTITY(1,1) PRIMARY KEY,
    Name      NVARCHAR(100) NOT NULL,
    Price     DECIMAL(18,2) NOT NULL CHECK (Price >= 0),
    Stock     INT           NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    CreatedAt DATETIME2     NOT NULL DEFAULT SYSDATETIME()
);
GO

-- ===== BANG ORDERS =====
CREATE TABLE Orders (
    Id        INT IDENTITY(1,1) PRIMARY KEY,
    UserId    INT           NOT NULL,
    ProductId INT           NOT NULL,
    Quantity  INT           NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    Total     DECIMAL(18,2) NOT NULL,
    Status    NVARCHAR(20)  NOT NULL DEFAULT N'pending',
    CreatedAt DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Orders_Users    FOREIGN KEY (UserId)    REFERENCES Users(Id),
    CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO
CREATE INDEX IX_Orders_UserId    ON Orders(UserId);
CREATE INDEX IX_Orders_ProductId ON Orders(ProductId);
GO

-- ===== SEED DATA =====
INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES
(N'admin',  N'admin@test.com',  N'hash_1', N'admin'),
(N'user1',  N'user1@test.com',  N'hash_2', N'user'),
(N'user2',  N'user2@test.com',  N'hash_3', N'user'),
(N'tester', N'tester@test.com', N'hash_4', N'user');

INSERT INTO Products (Name, Price, Stock) VALUES
(N'Laptop Dell',      15000000, 10),
(N'iPhone 15',        22000000, 25),
(N'Ban phim co',       1500000, 50),
(N'Chuot Logitech',     800000, 100),
(N'Man hinh LG',       7000000, 15);

INSERT INTO Orders (UserId, ProductId, Quantity, Total, Status) VALUES
(1, 1, 2, 30000000, N'completed'),
(2, 3, 1,  1500000, N'pending'),
(3, 2, 1, 22000000, N'shipped'),
(1, 5, 1,  7000000, N'completed');
GO

PRINT N'Tao database TestDB thanh cong!';
GO


