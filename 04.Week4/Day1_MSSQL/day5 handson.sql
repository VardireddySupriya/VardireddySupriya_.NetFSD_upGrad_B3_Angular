---handson on triggers,stored procedures,user defined functions
use StoredProceduresTriggers;
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50),
    city VARCHAR(50)
);
INSERT INTO stores VALUES
(1,'Central Store','Delhi'),
(2,'City Mall Store','Mumbai'),
(3,'Metro Store','Bangalore');
CREATE TABLE sales (
    sales_id INT PRIMARY KEY,
    sales_name VARCHAR(50),
    store_id INT,
    salary DECIMAL(10,2),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
INSERT INTO sales VALUES
(101,'Rahul',1,25000),
(102,'Priya',2,27000),
(103,'Amit',3,26000),
(104,'Neha',1,24000);
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    sales_id INT,
    store_id INT,
    order_date DATE,
    order_amount DECIMAL(10,2),
    FOREIGN KEY (sales_id) REFERENCES sales(sales_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
INSERT INTO orders VALUES
(1001,101,1,'2024-01-10',5000),
(1002,102,2,'2024-01-12',7000),
(1003,103,3,'2024-01-15',6000),
(1004,104,1,'2024-01-20',8000);
INSERT INTO orders VALUES
(1005,101,1,'2023-01-10',9000),
(1006,102,2,'2022-01-12',15000),
(1007,103,3,'2023-12-15',10000),
(1008,104,1,'2022-12-20',4000);

---Create a stored procedure to generate total sales amount per store.
AlTER procedure usp_getTotalSales
as
Begin
    select
	  st.store_name,
	  sum(o.order_amount) as total_sales
	from sales s
	inner join orders o
	  on s.sales_id=o.sales_id
	inner join stores st
	  on o.store_id=st.store_id
	Group by st.store_name;
End;

EXEC usp_getTotalSales;

---Create a stored procedure to retrieve orders by date range.
--hardcode value
create procedure ordersByDateRange
as
Begin
     select 
	     order_date
	from orders
	where order_date between '2024-01-01' and'2024-12-31';
End;

--dynamic values

create procedure ordersByDateRange1
@startDate Date,
@endDate Date
as
Begin
     select 
	     order_date
	from orders
	where order_date between @startDate and @endDate;
End;

EXEC ordersByDateRange1 '2023-01-01','2023-12-31';

----Create a scalar function to calculate total price after discount.

create function dbo.calculateTotal(@price Decimal(10,2),@discount Decimal(5,2))
Returns Decimal(10,2)
AS
Begin
    Declare @finalPrice Decimal(10,2);
	set @finalPrice=@price - (@price * @discount/100);
	Return @finalPrice;

End;

select dbo.calculateTotal(2000,10) as final_price;


----Create a table-valued function to return top 5 selling products.

create table topSellingProducts(
product_id int primary key,
product_name varchar(50),
);
CREATE TABLE order1(
    order_id INT PRIMARY KEY,
    quantity INT,
    order_amount INT,
    product_id INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO order1 VALUES
(101,5,5000,1),
(102,10,8000,2),
(103,7,3500,3),
(104,12,9000,2),
(105,6,3000,1);
CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);
INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Keyboard'),
(4,'Mouse'),
(5,'Headphones');

CREATE FUNCTION topSellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(o.quantity) AS total_quantity_sold
    FROM products p
    INNER JOIN order1 o
        ON p.product_id = o.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY total_quantity_sold DESC
);

select * from topSellingProducts();


------problem2------

---Create an AFTER INSERT trigger on order_items.

CREATE TABLE orderTable (
    order_id INT,
    log_date DATETIME,
    message VARCHAR(100)
);
create table order2(
order_id int primary key,
amount Decimal(10,2));


create trigger InsertTrigger1
on order2
AFTER INSERT
AS
BEGIN
     Declare @orderId int;
	 select @orderId=order_id from inserted;
	 insert into orderTable(order_id,log_date,message) values(@orderId,GETDATE(),'inserted');
	 print 'after insert';
End;

select * from orderTable

SELECT * FROM order2

INSERT INTO order2 VALUES(104,3000);

------ Reduce the corresponding quantity in stocks table.
 --Prevent stock from becoming negative.
 --If stock is insufficient, rollback the transaction with a custom error message.

 CREATE TABLE product1 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    price DECIMAL(10,2)
);
INSERT INTO product1 VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Keyboard',800),
(4,'Mouse',500);
CREATE TABLE stock (
    product_id INT PRIMARY KEY,
    stock_quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO stock VALUES
(1,50),
(2,40),
(3,60),
(4,30);
CREATE TABLE order_trig(
    order_id INT PRIMARY KEY,
    order_date DATE,
    customer_name VARCHAR(50)
);
INSERT INTO order_trig VALUES
(101,'2024-01-10','Rahul'),
(102,'2024-01-12','Priya');
CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES order_trig(order_id),
    FOREIGN KEY (product_id) REFERENCES product1(product_id)
);
--drop table order_items;
INSERT INTO order_items VALUES
(1,101,1,2,50000),
(2,101,3,1,800),
(3,102,2,1,20000);

------ Reduce the corresponding quantity in stocks table.

create trigger trg_reduce
on order_items
after insert
AS
Begin
      update s
	  set s.stock_quantity=s.stock_quantity - i.quantity
	  from stock s
	  inner join inserted i
	  on s.product_id=i.product_id;
End;
INSERT INTO order_items VALUES (4,102,2,1,20000);

select * from stock


 --Prevent stock from becoming negative.
 --If stock is insufficient, rollback the transaction with a custom error message.
CREATE TRIGGER trg_CheckStock
ON order_items
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM stock s
        JOIN inserted i
        ON s.product_id = i.product_id
        WHERE s.stock_quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock. Order cannot be processed.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    
    UPDATE s
    SET s.stock_quantity = s.stock_quantity - i.quantity
    FROM stock s
    JOIN inserted i
    ON s.product_id = i.product_id;

END;
INSERT INTO order_items VALUES(10,101,1,20,50000);

------problem3-----
create table order_p4(
order_id1 int primary key,
shipment_date date,
order_status int);
--drop table order_p4;
insert into order_p4 values
(1011,'2024-05-23',4),
(1012,null,1),
(1013,'2024-06-18',4),
(1014,'2023-05-13',4);
insert into order_p4 values
(1015,'2024-05-23',2),
(1016,'2023-10-23',1);

----Create an AFTER UPDATE trigger on orders.
CREATE TRIGGER trg_validateShipping
ON order_p4
AFTER UPDATE
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE order_status = 4
        AND shipment_date IS NULL
    )
    BEGIN
        RAISERROR ('Shipped date must not be NULL when order_status = 4',16,1);
        ROLLBACK TRANSACTION;
    END

END;
UPDATE order_p4
SET order_status = 4
WHERE order_id1 = 1015;

select* from order_p4;

----problem4-----
-- Temporary table to store revenue
CREATE TABLE #temp_revenue (
    order_id INT,
    store_id INT,
    revenue DECIMAL(10,2)
);

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @discount DECIMAL(10,2)
DECLARE @total DECIMAL(10,2)
-- Cursor for completed orders
DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id, discount
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor
INTO @order_id, @store_id, @discount

WHILE @@FETCH_STATUS = 0
BEGIN

    
    SELECT @total = SUM(quantity * price)
    FROM order_items
    WHERE order_id = @order_id

    
    SET @total = @total - ISNULL(@discount,0)

    
    INSERT INTO #temp_revenue
    VALUES (@order_id, @store_id, @total)

    FETCH NEXT FROM order_cursor
    INTO @order_id, @store_id, @discount

END

CLOSE order_cursor
DEALLOCATE order_cursor

SELECT 
    store_id,
    SUM(revenue) AS total_store_revenue
FROM #temp_revenue
GROUP BY store_id;



  

