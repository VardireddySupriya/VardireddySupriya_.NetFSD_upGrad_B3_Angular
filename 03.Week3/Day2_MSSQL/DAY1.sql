
--creating database
CREATE DATABASE DAY1;
--use database
USE  DAY1;

-- creating table as userinfo
Create table UserInfo(
    EmailId varchar(20) primary key,
	UserName varchar(50) Not Null check(len(UserName) between 1 and 50),
	Role varchar(30) Not Null Check(Role in('Admin','participant')),
	password varchar(20) Not Null check(len(password) between 6 and 20)
);
insert into UserInfo values('hello@gmail.com','kalpana','Admin','kalpana123');
select* from UserInfo;





-- 2.creating table eventdetails

Create Table EventDetails(
   EventId int primary key,
   EventName varchar(50) Not Null check(len(EventName) between 1 and 50),
   EventCategory varchar(50) Not Null check(len(EventCategory) between 1 and 50),
   EventDate datetime Not Null,
   Description varchar(30) Null,
   Status varchar(30) check(Status in('Active','In-Active'))
);
INSERT INTO EventDetails VALUES (1,'Tech Fest','Technology','2026-03-10','College event','Active');
select* from EventDetails;




-- creating table SpeakersDetails

Create Table SpeakersDetails(
    SpeakerId int primary key,
	SpeakerName varchar(50) Not Null check(len(SpeakerName) between 1 and 50)
);
Insert Into SpeakersDetails values('1','sharma');
select* from SpeakersDetails;


--create Table SessionInfo

Create Table SessionInfo(
      SessionId int  primary key,
	  EventId int Not Null,
	  SessionTitle varchar(50) Not Null check(len(SessionTitle) between 1 and 50),
	  SpeakerId int Not Null ,
	  Description varchar(200) Null,
	  SessionStart datetime Not Null,
	  SessionEnd datetime Not Null,
	  SessionUrl varchar(200),
	  Foreign key(EventId) References EventDetails(EventId),
	  Foreign key(SpeakerId) References SpeakersDetails(SpeakerId)
);
Insert Into SessionInfo values(1,1,'sql',1,NULL,'2026-03-05 8:00:00','2026-03-05 12:00:00','www.session.com');
select* from SessionInfo;



--- create table ParticipantEventDetails

create Table ParticipantEventDetails(
     Id int primary key,
	 ParticipantEmailId varchar(20) Not Null ,
	 EventId int Not Null ,
	 SessionId int Not Null ,
	 IsAttended bit check(IsAttended in(1,0)),
	 Foreign key(ParticipantEmailId) References UserInfo(EmailId) ,
	 Foreign key(EventId) References EventDetails(EventId),
	 Foreign key(SessionId) References SessionInfo(SessionId)


);
Insert Into ParticipantEventDetails values(1,'hello@gmail.com',1,1,1);
Select * from ParticipantEventDetails;
Drop table UserInfo;
Drop table EventDetails;
drop table ParticipantEventDetails;
drop table SessionInfo;


--- practice
--1.select count(*) as totalemp from employees;
--2.Select avg(salary) as averagesalary from employees;
--3.select max(salary) as maximumsalary from employees;
--4.select min(salary) as minimumsalary from employees;
--5.select sum(salary) as totalsalary from employees;


--- create table emp

CREATE TABLE Dept (
    Deptno INT PRIMARY KEY,
    Dname VARCHAR(30),
    Loc VARCHAR(30)
);

CREATE TABLE Emp (
    Empno INT PRIMARY KEY,
    Ename VARCHAR(30),
    Job VARCHAR(30),
    Salary INT,
    Deptno INT,
    FOREIGN KEY (Deptno) REFERENCES Dept(Deptno)
);

INSERT INTO Dept VALUES
(10,'HR','Hyderabad'),
(20,'IT','Bangalore'),
(30,'Sales','Chennai'),
(40,'Finance','Mumbai');

INSERT INTO Emp VALUES
(101,'Ravi','Manager',60000,10),
(102,'Sita','Developer',45000,20),
(103,'Arjun','Developer',50000,20),
(104,'Meena','Sales Executive',35000,30),
(105,'Kiran','Accountant',40000,40),
(106,'John','Manager',65000,20),
(107,'Anita','HR Executive',30000,10),
(108,'Raj','Sales Executive',37000,30);
select * from emp;
select * from dept;

update emp set salary=80000 where empno=101;
delete from emp where empno=101;

select ename,salary from emp;
select ename,job from emp;
select distinct(job) from emp;

select salary from emp order by salary;
select salary from emp order by salary desc;
select  salary from emp order by salary desc OFFSET 1 ROWS FETCH NEXT 1 ROW ONLY;


----- day 2
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

select p.productName,s.storeName,sum(st.quantity) as availableStockQuantity,sum(o.quantity) as totalQuantitySold
from stocks st inner join products p
on st.productId=p.productId
inner Join stores s
on st.storeId=s.storeId
left Join order_items o
on st.productId=o.productId
group by p.productName,s.storeName
order by p.productName;


