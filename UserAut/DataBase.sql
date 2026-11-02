CREATE DATABASE TestUser1;
GO

USE TestUser1;
GO

CREATE TABLE [User] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    full_name NVARCHAR(150) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    email NVARCHAR(150) NOT NULL,
    login NVARCHAR(50) NOT NULL,
    pass NVARCHAR(255) NOT NULL,
    is_admin BIT NOT NULL DEFAULT 0
);
GO

INSERT INTO [User] (full_name, phone, email, login, pass, is_admin)
VALUES 
('Иванов Иван Иванович', '+79001112233', 'ivanov@example.com', 'ivanov', '1234', 1),
('Петров Пётр Петрович', '+79004445566', 'petrov@example.com', 'petrov', '5678', 1),
('Сидорова Анна Сергеевна', '+79007778899', 'sidorova@example.com', 'anna', '1111', 0),
('Кузнецов Дмитрий Олегович', '+79002223344', 'kuznetsov@example.com', 'dmitry', '2222', 0),
('Смирнова Ольга Игоревна', '+79005556677', 'smirnova@example.com', 'olga', '3333', 0),
('Волков Алексей Николаевич', '+79008889900', 'volkov@example.com', 'volkov', '4444', 0),
('Морозова Екатерина Павловна', '+79003334455', 'morozova@example.com', 'kate', '5555', 0),
('Новиков Сергей Андреевич', '+79006667788', 'novikov@example.com', 'sergey', '6666', 0),
('Фёдорова Мария Дмитриевна', '+79009990011', 'fedorova@example.com', 'maria', '7777', 0),
('Григорьев Павел Викторович', '+79001232345', 'grigoriev@example.com', 'pavel', '8888', 0);
GO