
create database day3;

use day3;

----Subquery

--problem1--Product Analysis Using Nested Queries

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT
);

INSERT INTO products VALUES
(1,'Road Bike',2019,1800,1),
(2,'Mountain Bike',2020,2000,1),
(3,'Touring Bike',2018,1200,1),
(4,'Electric Scooter',2021,900,2),
(5,'Electric Bike',2022,2500,2),
(6,'Kids Bike',2019,500,3);

select product_name, model_year, list_price 
from products ;
--compare each product within the same category
SELECT 
    p1.product_name,
    p1.category_id,
    p1.list_price,
    (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p1.category_id = p2.category_id
    ) AS category_avg_price
FROM products p1;


select product_name 
from products p1
where list_price>(select avg(list_price) as avgprice from products p2 where p1.category_id=p2.category_Id);

SELECT product_name,
list_price -
(
    SELECT AVG(list_price) as category_price
    FROM products p2
    WHERE p1.category_id = p2.category_id
) AS price_difference
FROM products p1;
--concatenation

select concat(product_Name,'(',model_year,')') as productName from products;


----problem2 --Customer Activity Classification
CREATE TABLE customer (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
INSERT INTO customer VALUES
(1,'Ravi','Kumar'),
(2,'Priya','Sharma'),
(3,'Arun','Reddy'),
(4,'Meena','Patel');
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT,
    order_amount DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);
INSERT INTO orders VALUES
(101,1,'2023-01-10','2023-01-20','2023-01-18',2,5000),
(102,1,'2023-03-15','2023-03-25','2023-03-28',2,3000),
(103,2,'2022-02-10','2022-02-20','2022-02-18',3,2000),
(104,2,'2024-01-05','2024-01-15','2024-01-14',2,4500),
(105,3,'2021-12-01','2021-12-10','2021-12-12',3,1500),
(106,4,'2024-02-10','2024-02-20','2024-02-18',1,3500);
INSERT INTO orders VALUES
(107, NULL, '2024-03-01', '2024-03-10', NULL, 1, 4000),
(108, 3, NULL, '2024-03-15', NULL, 2, NULL),
(109, 2, '2024-04-01', NULL, NULL, NULL, 2500);

SELECT 
    customer_name,
    total_order_value,
    CASE 
        WHEN total_order_value > 10000 THEN 'Premium'
        WHEN total_order_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_type
FROM
(
    SELECT 
        c.first_name + ' ' + c.last_name AS customer_name,
        (SELECT SUM(o.order_amount)
         FROM orders o
         WHERE o.customer_id = c.customer_id) AS total_order_value
    FROM customer c
) AS customer_orders;

---union
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    o.order_id,
    o.order_amount
FROM customer c
INNER JOIN orders o
ON c.customer_id = o.customer_id

UNION

SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    NULL AS order_id,
    NULL AS order_amount
FROM customer c
WHERE c.customer_id NOT IN (
    SELECT customer_id FROM orders
);

---problem 4

CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT,
    order_amount DECIMAL(10,2)
);
--drop table archived_orders;
INSERT INTO archived_Orders (order_id, customer_id, order_date, shipped_date, required_date, order_status, order_amount)
SELECT order_id, customer_id, order_date, shipped_date, required_date, order_status, order_amount
FROM orders;

select * from archived_orders;

--delete the records
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());
select * from orders;


--nested query

select customer_id,first_name+' '+last_name as customer_name 
from customer 
where customer_id not in(
select customer_id from orders
 WHERE order_status <> 2
 );


 --datediff

SELECT order_id,
       customer_id,
       shipped_date,
       order_date,
       DATEDIFF(day, order_date, shipped_date) AS processing_delay_days
FROM orders;

--delayed or ontime

SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE 
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status
FROM orders;



--problem3CREATE TABLE products1(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price INT
);

CREATE TABLE stores(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE orders1(
    order_id INT PRIMARY KEY,
    product_id INT,
    store_id INT,
    total_quantity INT,
    discount INT
);

CREATE TABLE stocks(
    store_id INT,
    product_id INT,
    quantity INT
);INSERT INTO products1 VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Tablet',15000),
(4,'Headphones',2000),
(5,'Smart Watch',8000);INSERT INTO stores VALUES
(1,'Bangalore Store'),
(2,'Delhi Store'),
(3,'Mumbai Store');INSERT INTO orders VALUES
(101,1,1,2,1000),
(102,2,1,3,500),
(103,3,2,1,200),
(104,4,2,5,100),
(105,2,3,2,300);INSERT INTO stocks VALUES
(1,1,10),
(1,2,20),
(2,3,15),
(2,4,25),
(3,5,30);select product_namefrom products where product_id=(select product_id from orders1 where store_id=1);----. Display store_name, product_name, total quantity sold.select st.store_Name,p.product_name,sum(o.total_quantity) as totalQuantityfrom products1 p join orders1 oon p.product_id=o.product_idinner join stores stst.store_id=o.store_idgroup by store_name;--Calculate total revenue per product (quantity × list_price – discount).select product_name,sum(o.(total_quantity × list_price )-o.discount) as totalRevenue from products1 inner join orders1on p.product_id=o.product_idgroup by product_name;----intersectSELECT product_id 
FROM orders1

INTERSECT

SELECT product_id 
FROM stocks;
---except

SELECT product_id 
FROM orders1

EXCEPT

SELECT product_id 
FROM stocks;