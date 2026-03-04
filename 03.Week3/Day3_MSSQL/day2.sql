--Problem 1 - Basic Customer Order Report

Create Table Customers(
customerId int primary key,
firstName varchar(50) Not Null,
lastName varchar(50) Not Null
);
--drop table Customers;
insert into Customers values
(101,'sudheer','Reddy'),
(102,'sravan','Reddy'),
(103,'kiran','Reddy');
create Table Orders(
orderId int primary Key,
orderDate date Not Null,
orderStatus varchar(20) Not Null,
customerId int Not Null Foreign Key(customerId) References Customers(customerId)
);
--drop table Orders;
insert into Orders values
(1,'2026-03-03','completed',101),
(2,'2026-04-03','pending',101),
(3,'2026-01-02','completed',102),
(4,'2026-05-01','completed',103),
(5,'2026-05-03','failure',102);


select c.firstName, c.lastName, o.orderId,o.orderDate,o.orderStatus 
from Orders o Inner Join Customers c
on o.customerId=c.customerId
where o.orderStatus in('pending','completed')
order by o.orderDate desc ;


--- problem 2-Product Price Listing by Category

CREATE TABLE Brands (
    brandId INT PRIMARY KEY,
    brandName VARCHAR(50) NOT NULL,
	modelYear DATE NOT NULL
);
INSERT INTO Brands VALUES
(1, 'Nike', '2023-01-01'),
(2, 'Adidas', '2023-01-01'),
(3, 'Puma', '2024-01-01');

CREATE TABLE Categories (
    categoryId INT PRIMARY KEY,
    categoryName VARCHAR(50) NOT NULL,
	brandId int Not Null Foreign Key(brandId) References Brands(brandId)
);
INSERT INTO Categories VALUES
(101, 'Shoes', 1),
(102, 'T-Shirts', 1),
(103, 'Sports Wear', 2),
(104, 'Jackets', 3);

CREATE TABLE Product (
    productId INT PRIMARY KEY,
    productName VARCHAR(50) NOT NULL,
    listPrice DECIMAL(10,2),
    brandId INT,
    categoryId INT,
    FOREIGN KEY (brandId) REFERENCES Brands(brandId),
    FOREIGN KEY (categoryId) REFERENCES Categories(categoryId)
);
INSERT INTO Product VALUES
(1001, 'Nike Air Max', 5000.00, 1, 101),
(1002, 'Nike Sports Tee', 1500.00, 1, 102),
(1003, 'Adidas Running Shoe', 4500.00, 2, 103),
(1004, 'Puma Winter Jacket', 6500.00, 3, 104);


select p.productName, b.brandName, c.categoryName, b.modelYear,p.listPrice
from Brands b inner join product p
on P.brandId = B.brandId
inner join Categories c
on p.categoryId=c.categoryId
where listPrice>500
order by listPrice;


--problem3-Store Wise Sales Summary

CREATE TABLE stores (
    storeId INT PRIMARY KEY,
    storeName VARCHAR(100) NOT NULL,
    city VARCHAR(50)
);
INSERT INTO stores VALUES
(1, 'Bangalore Store', 'Bangalore'),
(2, 'Chennai Store', 'Chennai'),
(3, 'Hyderabad Store', 'Hyderabad');
CREATE TABLE Orders1 (
    orderId INT PRIMARY KEY,
    storeId INT NOT NULL,
    quantity INT NOT NULL,
    listPrice DECIMAL(10,2) NOT NULL,
    discount DECIMAL(4,2) DEFAULT 0,
    orderStatus INT NOT NULL,
    orderDate DATE,
    FOREIGN KEY (storeId) REFERENCES stores(storeId)
);
INSERT INTO Orders1 VALUES
(101, 1, 2, 5000, 0.10, 4, '2024-01-10'),
(102, 1, 1, 3000, 0.05, 4, '2024-01-15'),
(103, 2, 3, 2000, 0.00, 4, '2024-01-20'),
(104, 3, 5, 1500, 0.20, 3, '2024-01-25');  

select s.storeName,sum(o.quantity * o.listPrice * (1 - o.discount)) as totalSalesAmount
from stores s inner join Orders1 o
on s.storeId=o.storeId
where orderStatus=4
group by s.storeName
order by totalSalesAmount desc;


--problem 4-- Product Stock and Sales Analysis

CREATE TABLE products (
    productId INT PRIMARY KEY,
    productName VARCHAR(100) NOT NULL,
    listPrice DECIMAL(10,2)
);
CREATE TABLE stores (
    storeId INT PRIMARY KEY,
    storeName VARCHAR(100) NOT NULL,
    city VARCHAR(50)
);

CREATE TABLE stocks (
    storeId INT,
    productId INT,
    quantity INT NOT NULL,
    PRIMARY KEY (storeId, productId),
    FOREIGN KEY (storeId) REFERENCES stores(storeId),
    FOREIGN KEY (productId) REFERENCES products(productId)
);
CREATE TABLE order_items (
    orderItemId INT PRIMARY KEY,
    productId INT NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (productId) REFERENCES products(productId)
);
INSERT INTO products VALUES
(1, 'Laptop', 50000.00),
(2, 'Mouse', 800.00),
(3, 'Keyboard', 1500.00),
(4, 'Monitor', 12000.00);
INSERT INTO stores VALUES
(1, 'Bangalore Store', 'Bangalore'),
(2, 'Chennai Store', 'Chennai'),
(3, 'Hyderabad Store', 'Hyderabad');
INSERT INTO stocks VALUES
(1, 1, 10),   
(1, 2, 50),   
(1, 3, 30),   
(2, 1, 5),    
(2, 4, 20),   
(3, 2, 40);  
INSERT INTO order_items VALUES
(101, 1, 3),  
(102, 1, 2),   
(103, 2, 10),  
(104, 4, 5);   

select p.productName,s.storeName,sum(st.quantity) as availableStockQuantity,sum(o.quantity) as totalQuantitySold
from stocks st inner join products p
on st.productId=p.productId
inner Join stores s
on st.storeId=s.storeId
left Join order_items o
on st.productId=o.productId
group by p.productName,s.storeName
order by p.productName;

