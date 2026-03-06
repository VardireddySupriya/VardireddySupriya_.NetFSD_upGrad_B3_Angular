
create database Ecommdb;

use Ecommdb;
--create categories table

Create Table categories (
    category_id Int Primary Key,
    category_name VARCHAR(50) NOT NULL
);
--insert values into category table

INSERT INTO categories VALUES
(1,'Electronics'),
(2,'Clothing'),
(3,'Furniture'),
(4,'Sports'),
(5,'Books');

--create brands table

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50) NOT NULL
);

--insert values into brands table

INSERT INTO brands VALUES
(1,'Samsung'),
(2,'Nike'),
(3,'Apple'),
(4,'Adidas'),
(5,'Sony');

--create products table

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
	store_id int,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

--insert values into product tables

INSERT INTO products VALUES
(1,'Galaxy S23',1,1,2024,75000),
(2,'AirPods Pro',3,1,2023,25000),
(3,'Running Shoes',2,4,2024,5000),
(4,'LED TV',5,1,2023,45000),
(5,'Sports Jacket',4,2,2024,3500);

-- create table customers

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone VARCHAR(15),
    email VARCHAR(100),
    city VARCHAR(50)
);

--insert values into customer table

INSERT INTO customers VALUES
(1,'Rahul','Sharma','9876543210','rahul@gmail.com','Delhi'),
(2,'Priya','Verma','9123456780','priya@gmail.com','Mumbai'),
(3,'Amit','Kumar','9988776655','amit@gmail.com','Bangalore'),
(4,'Neha','Singh','9871234567','neha@gmail.com','Hyderabad'),
(5,'Rohan','Das','9765432109','rohan@gmail.com','Chennai');

INSERT INTO customers VALUES
(6,'kalyan','Kumar','9988776655','kalyan@gmail.com','Bangalore'),
(7,'Nainika','Singh','9871234678','nainika@gmail.com','Hyderabad');



--create table stores

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    phone VARCHAR(15),
    city VARCHAR(50),
	customer_id int
	foreign key(customer_id) References customers(customer_id)
);
--drop table stores;

--insert values into stores

INSERT INTO stores VALUES
(101,'Tech Store','9012345678','Bangalore',3),
(102,'Fashion Hub','9023456789','Mumbai',2),
(103,'Sports World','9034567890','Delhi',1),
(104,'Mega Electronics','9045678901','Hyderabad',4),
(105,'Book Center','9056789012','Chennai',5);


----Write SELECT queries to retrieve all products with their brand and category names.

select p.product_name,c.category_name,b.brand_name
from categories c
inner join products p
on c.category_id=p.category_id
inner join brands b
on b.brand_id=p.brand_id;

----Retrieve all customers from a specific city.

select first_name+''+last_name as customer_name from customers where city='delhi';

-----Display total number of products available in each category.

select count(p.product_Id),category_name
from products p
inner join categories c
on p.category_id=c.category_id
group by category_name;


---problem2 views and indexes

--- Create a view that shows product name, brand name, category name, model year and list price.

CREATE VIEW categoryProduct as
SELECT 
    p.product_name,
    c.category_name,
    b.brand_name,
    p.model_year,
    p.list_price
FROM categories c
INNER JOIN products p
    ON c.category_id = p.category_id
INNER JOIN brands b
    ON b.brand_id = p.brand_id;

--select * from categoryProduct where model_year=2023;

---- Create a view that shows order details with customer name, store name and staff name.

create view customerStore as
select
   c.last_name+''+c.first_name as customer_name,
   s.store_name
 from customers c 
 inner join stores s
 on c.customer_id=s.customer_id;

 select * from customerStore;

 ---Create appropriate indexes on foreign key columns.
  
 create nonclustered index 
 idx_brand on brands(brand_id);

 create nonclustered index 
 idx_category on categories(category_id);

 create nonclustered index 
 idx_products on products(product_id);
 

  --create unique index

  create unique index
  idx_email on customers(email);

  exec sp_helpindex 'products';


