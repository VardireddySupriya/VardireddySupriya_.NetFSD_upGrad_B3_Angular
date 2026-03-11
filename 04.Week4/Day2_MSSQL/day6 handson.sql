
create database transactions;

use transactions;



CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT,
    order_date DATETIME,
    order_status VARCHAR(20)
);
CREATE TABLE order_items (
    item_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

---problem1--- Transactions and Trigger Implementation

----Write a transaction to insert data into orders and order_items tables.----
-----Check stock availability before confirming order.---
---Rollback transaction if stock quantity is insufficient.
CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
stock_quantity INT
);
INSERT INTO products VALUES
(201,'Laptop',10),
(202,'Mouse',50);


DECLARE @order_id INT;
Declare @order_status varchar(20)='completed';
DECLARE @customer_id INT = 101;
DECLARE @product_id INT = 201;
DECLARE @quantity INT = 3;
DECLARE @price DECIMAL(10,2) = 500;
Declare @stock int;
Begin Transaction;
Begin Try
      
	  select @stock=stock_quantity
	  from products
	  where product_id=@product_id;
	  if @stock<@quantity
	  Begin
	      print 'insufficient funds';
		  Rollback Transaction;
		  Return;
	  End
      insert into orders(customer_id,order_date,order_status)
	  values(@customer_id,GETDATE(),@order_status);

	  set @order_id=SCOPE_IDENTITY();

	  insert into order_items(order_id,product_id,quantity,price)
	  values(@order_id,@product_id,@quantity,@price);

	  commit Transaction;
End Try
Begin Catch
      Rollback Transaction;
	  print 'Transaction Failed';

End Catch



select* from orders;
select* from order_items;
select* from products;

----triggers----
create trigger trg_reduce_stock
on order_items
after insert
as
Begin
   update p
   set p.stock_quantity=p.stock_quantity-i.quantity
   from inserted i
   join products p
   on p.product_id=i.product_id;
End


---problem2--atomic order cancallation----
--- Begin a transaction when cancelling an order.
---Restore stock quantities based on order_items.
--- Update order_status to 3.
--Use SAVEPOINT before stock restoration.
--If stock restoration fails, rollback to SAVEPOINT.
--Commit transaction only if all operations succeed.

Declare @order_id int=100;
Begin Transaction;
Begin Try

   update orders
   Set order_status=2
   where order_id=@order_id;

   SAVE TRANSACTION savepointBeforeStockRestore;

   --stock restoration
   update p
   set p.stock_quantity=p.stock_quantity+oi.quantity
   From products p
    Join order_items oi
    On p.product_id = oi.product_id
    Where oi.order_id = @order_id;
    Commit Transaction;
End Try
Begin Catch
   ROLLBACK TRANSACTION;

    PRINT 'Cancel Order Failed';
	PRINT 'Stock restoration failed. Rolled back to SAVEPOINT.';
End Catch

select* from orders;
select* from order_items;
select* from products;



     




