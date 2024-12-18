-- ������� �������������
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,               -- ���������� ������������� ������������
    FirstName NVARCHAR(100) NOT NULL,                   -- ��� ������������
    LastName NVARCHAR(100) NOT NULL,                    -- ������� ������������
    Email NVARCHAR(255) NOT NULL UNIQUE,                -- ����������� ����� 
    DateCreated DATETIME NOT NULL DEFAULT GETDATE()     -- ���� �������� ������� ������
);

-- ������� �������
CREATE TABLE Brands (
    BrandID INT IDENTITY(1,1) PRIMARY KEY,              -- ���������� ������������� ������
    Name NVARCHAR(255) NOT NULL UNIQUE,                 -- �������� ������
    Description NVARCHAR(MAX),                          -- �������� ������
    Website NVARCHAR(255),                              -- ���-���� ������
    DateAdded DATETIME NOT NULL DEFAULT GETDATE()       -- ���� ���������� ������ �� ���������
);

-- ������� �������
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,            -- ���������� ������������� ������
    Name NVARCHAR(255) NOT NULL,                        -- �������� ������
    Description NVARCHAR(MAX),                          -- �������� ������
    Price DECIMAL(10, 2) NOT NULL,                      -- ���� ������
    Stock INT NOT NULL,                                 -- ���������� ������ �� ������
    BrandID INT NOT NULL FOREIGN KEY REFERENCES Brands(BrandID),
    DateAdded DATETIME NOT NULL DEFAULT GETDATE()       -- ���� ���������� ������ �� ���������
);

-- ������� �������
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,              -- ���������� ������������� ������
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),      -- ���� ���������� ������
    TotalAmount DECIMAL(10, 2) NOT NULL,                -- ����� ����� ������
    Status NVARCHAR(50) NOT NULL,
);

-- ������� �������
CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,             -- ���������� ������������� ������
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID), -- ����� � ������� 
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID), -- ����� � ������������� 
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5), -- ������ ������ (�� 1 �� 5)
    Comment NVARCHAR(MAX),                              -- ����� �����������
    DatePosted DATETIME NOT NULL DEFAULT GETDATE()      -- ���� ���������� ������
);
