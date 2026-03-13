create database Practice;
use Practice;
CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY

        IF @Stock < 0 OR @Price <= 0
        BEGIN
            RAISERROR('Invalid stock or price.',16,1);
        END

        INSERT INTO Books(Title, Stock, Price)
        VALUES(@Title, @Stock, @Price);

        PRINT 'Book added successfully.';

    END TRY

    BEGIN CATCH
        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) 
        + ': ' + ERROR_MESSAGE();
    END CATCH
END

EXEC sp_AddNewBook 'SQL Basics', 10, 450.00;
EXEC sp_AddNewBook 'C# Programming', 5, 650.00;
EXEC sp_AddNewBook 'Database Design', 7, 550.00;
EXEC sp_AddNewBook 'ASP.NET Core', 4, 700.00;


---main procedure------
CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

SET XACT_ABORT ON;

BEGIN TRY

    BEGIN TRANSACTION;

    IF NOT EXISTS (
        SELECT 1 FROM Books
        WHERE BookID = @BookID AND Stock >= @Quantity
    )
    BEGIN
        RAISERROR('Not enough stock or book not found.',16,1);
    END

    UPDATE Books
    SET Stock = Stock - @Quantity
    WHERE BookID = @BookID;

    INSERT INTO Orders(BookID, Quantity)
    VALUES(@BookID, @Quantity);

    COMMIT TRANSACTION;

    PRINT 'Order placed successfully.';

END TRY

BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) 
    + ': ' + ERROR_MESSAGE();

END CATCH

END
EXEC sp_PlaceOrder 2, 20;
