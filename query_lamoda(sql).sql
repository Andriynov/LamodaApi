-- Таблица пользователей
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,               -- Уникальный идентификатор пользователя
    FirstName NVARCHAR(100) NOT NULL,                   -- Имя пользователя
    LastName NVARCHAR(100) NOT NULL,                    -- Фамилия пользователя
    Email NVARCHAR(255) NOT NULL UNIQUE,                -- Электронная почта 
    DateCreated DATETIME NOT NULL DEFAULT GETDATE()     -- Дата создания учетной записи
);

-- Таблица брендов
CREATE TABLE Brands (
    BrandID INT IDENTITY(1,1) PRIMARY KEY,              -- Уникальный идентификатор бренда
    Name NVARCHAR(255) NOT NULL UNIQUE,                 -- Название бренда
    Description NVARCHAR(MAX),                          -- Описание бренда
    Website NVARCHAR(255),                              -- Веб-сайт бренда
    DateAdded DATETIME NOT NULL DEFAULT GETDATE()       -- Дата добавления бренда на платформу
);

-- Таблица товаров
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,            -- Уникальный идентификатор товара
    Name NVARCHAR(255) NOT NULL,                        -- Название товара
    Description NVARCHAR(MAX),                          -- Описание товара
    Price DECIMAL(10, 2) NOT NULL,                      -- Цена товара
    Stock INT NOT NULL,                                 -- Количество товара на складе
    BrandID INT NOT NULL FOREIGN KEY REFERENCES Brands(BrandID),
    DateAdded DATETIME NOT NULL DEFAULT GETDATE()       -- Дата добавления товара на платформу
);

-- Таблица заказов
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,              -- Уникальный идентификатор заказа
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),      -- Дата оформления заказа
    TotalAmount DECIMAL(10, 2) NOT NULL,                -- Общая сумма заказа
    Status NVARCHAR(50) NOT NULL,
);

-- Таблица отзывов
CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,             -- Уникальный идентификатор отзыва
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID), -- Связь с товаром 
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID), -- Связь с пользователем 
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5), -- Оценка товара (от 1 до 5)
    Comment NVARCHAR(MAX),                              -- Текст комментария
    DatePosted DATETIME NOT NULL DEFAULT GETDATE()      -- Дата публикации отзыва
);
