CREATE DATABASE ToyStoreDB;
GO

-- Sử dụng database mới
USE ToyStoreDB;
GO

-- Tạo bảng Categories
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(MAX)
);
GO

-- Tạo bảng Products
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Price DECIMAL(18,2),
    StockQuantity INT,
	PhotoUrlThumnail NVARCHAR(MAX),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
	Status INT
);
GO

CREATE TABLE ProductUrls (
    ProductUrlID INT IDENTITY(1,1) PRIMARY KEY,
	ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
	ProductUrl NVARCHAR(MAX)
)

-- Tạo bảng Customers
CREATE TABLE Accounts (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
	Username NVARCHAR(100),
	Password NVARCHAR(100),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Address NVARCHAR(MAX),
    Phone NVARCHAR(20),
	RoleID INT,
	Status INT
);
GO

-- Tạo bảng Orders
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Accounts(AccountID),
	Address NVARCHAR(MAX),
    OrderDate DATETIME,
    TotalAmount DECIMAL(18,2),
	Status INT
);
GO

-- Tạo bảng OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    UnitPrice DECIMAL(18,2)
);
GO

-- Tạo bảng ProductReviews
CREATE TABLE ProductReviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    CustomerID INT FOREIGN KEY REFERENCES Accounts(AccountID),
    Rating INT,
    ReviewText NVARCHAR(MAX),
    ReviewDate DATETIME,
	Status INT
);
GO

-- Tạo bảng Feedback
CREATE TABLE Feedback (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Accounts(AccountID),
    FeedbackText NVARCHAR(MAX),
    FeedbackDate DATETIME
);
GO
