
 PROJECT DOCUMENTATION
Backend Mini E-Commerce API (.NET 10 Web API)
________________________________________
1️⃣ PROJECT OVERVIEW
This project is a backend RESTful API developed for an e-commerce system using ASP.NET Core Web API (.NET 10).
It provides secure user authentication, product management, and order processing with stock validation.
The system uses JWT-based authentication and Swagger for API testing and documentation.
________________________________________
2️⃣ OBJECTIVE
The main objective of this project is to design a secure and scalable backend system that supports:
•	User authentication and authorization 
•	Product inventory management 
•	Order processing with stock control 
•	REST API architecture 
•	Secure data handling using JWT 
________________________________________
3️⃣ TECHNOLOGY STACK
•	ASP.NET Core Web API (.NET 10) 
•	Entity Framework Core 
•	SQL Server Database 
•	JWT Authentication 
•	Postman
•	BCrypt Password Hashing 
________________________________________
4️⃣ ARCHITECTURE
The project follows a layered architecture:
•	Controllers: Handle HTTP requests and responses 
•	Services: Contain business logic 
•	Repository: Handles database operations 
•	Models: Represent database entities 
•	DTOs: Used for data transfer between client and server 
________________________________________
5️⃣ MODULES
 Authentication Module
Handles user registration and login using JWT authentication. It ensures secure access to APIs based on user roles.
________________________________________
 Product Module
Manages product-related operations such as adding, updating, deleting, and viewing products. It also manages stock levels.
________________________________________
Order Module
Handles order creation and retrieval. It includes stock validation, automatic stock deduction, and total price calculation.
________________________________________
6️⃣ AUTHENTICATION FLOW
•	User registers into the system 
•	User logs in with credentials 
•	System generates a JWT token 
•	Token is used to access secured APIs 
________________________________________
7️⃣ ORDER PROCESS FLOW
•	User places an order 
•	System validates request data 
•	Product availability is checked 
•	Stock quantity is verified 
•	Stock is reduced automatically after successful order 
•	Total price is calculated 
•	Order is stored in database 
________________________________________
8️⃣ STOCK VALIDATION
Before placing an order, the system checks product stock availability.
If requested quantity exceeds available stock, the order is rejected with an error message.
________________________________________
9️⃣ ORDER STATUS MANAGEMENT
Each order has a default status set as “Pending”.
Future updates can modify status based on business rules such as completion or cancellation.
________________________________________
🔟 DTO (DATA TRANSFER OBJECTS)
DTOs are used to transfer data between client and server in a secure and structured way.
They help in:
•	Preventing direct exposure of database models 
•	Reducing unnecessary data transfer 
•	Improving security and performance 
•	Maintaining clean architecture 
The project uses DTOs for:
•	User registration and login 
•	Order creation and response 
•	Product data transfer 
________________________________________
1️⃣1️⃣ DATABASE DESIGN
The system contains the following tables:
•	Users: Stores user information and roles 
•	Products: Stores product details and stock 
•	Orders: Stores order summary and status 
•	OrderItems: Stores individual products inside an order 
________________________________________
1️⃣2️⃣ API TESTING
Postman is used for testing and validating all REST APIs in this project. It helps in verifying authentication, product management, and order processing functionalities.
All endpoints such as user login, product operations, and order creation are tested using Postman.
JWT authentication is implemented, and the generated token is used in the Authorization header (Bearer Token) to access secured APIs.
________________________________________
1️⃣3️⃣ SECURITY FEATURES
•	Passwords are encrypted using hashing 
•	JWT tokens are used for authentication 
•	Role-based authorization is implemented 
•	Secure API access is enforced 
________________________________________
1️⃣4️⃣ FEATURES IMPLEMENTED
•	User Authentication (JWT) 
•	Role-based Authorization 
•	Product Management 
•	Order Processing 
•	Stock Validation 
•	Postman
•	DTO-based architecture

