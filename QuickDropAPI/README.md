# QuickDropAPI

QuickDropAPI is a personal ASP.NET Core Web API project for managing delivery requests.

The project allows users to register and log in securely using JWT authentication and provides functionality for creating, retrieving, updating, and deleting delivery records.

### Technologies

* C# / ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Docker
* JWT Authentication
* BCrypt
* Swagger / OpenAPI
* Repository, Service, and Logic layered architecture

### Current Features

* User registration and login
* Password hashing with BCrypt
* JWT authentication
* Delivery creation and management
* PostgreSQL database integration
* Entity Framework Core migrations
* Dockerized PostgreSQL database
* Swagger API documentation

### Planned Integrations

* Payment processing
* Maps/distance calculation
* Third-party logistics/dispatch services

### Architecture

The project follows a layered approach:

**Controller → Logic → Service → Repository → Database**

Third-party API integrations use `IHttpClientFactory` through a reusable custom HTTP service.

> This project is being developed as a personal learning project to strengthen my understanding of ASP.NET Core Web API, authentication, database integration, layered architecture, and third-party API integration.
