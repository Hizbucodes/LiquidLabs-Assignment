# LiquidLabs - Assignment

A RESTful **ASP.NET Core Web API** that fetches user data from the **JSONPlaceholder API** and caches it in **SQL Server** using the **DTO pattern** with **extension methods**.

---

## Description

This API demonstrates .NET development practices by implementing a form of **local caching**. It retrieves user data from the JSONPlaceholder's public API, stores it in SQL Server for faster access, and exposes clean RESTful endpoints.

Built **without an ORM**, it uses **raw SQL queries with parameterized statements** for direct database control.

---

## Tech Stack

- **Framework:** ASP.NET Core 8.0  
- **Language:** C# 
- **Database:** SQL Server
- **API Documentation:** Swagger / OpenAPI  
- **External API:** JSONPlaceholder  

### NuGet Packages
- `Microsoft.Data.SqlClient` – SQL Server connectivity without ORM  
- `Newtonsoft.Json` – JSON serialization / deserialization  

---

### Key Features

- **DTO Pattern** – Separate models for API responses and database entities  
- **Extension Methods** – Clean mapping between DTOs and entities  
- **Repository Pattern** – Abstracted data access with raw SQL queries  
- **Caching Strategy** – Database caching to reduce API calls  
- **Dependency Injection** – Loose coupling  

---

## How to Run the Project

### Prerequisites

- .NET 8.0 SDK or later  
- SQL Server  
- SQL Server Management Studio (SSMS)  

---

### Step 1: Clone the Repository

```bash
https://github.com/Hizbucodes/LiquidLabs-Assignment.git
cd LiquidLabs
```


### Step 2: Set Up the Database

#### Using SQL Server Management Studio (SSMS)

 1) Open SSMS and connect to your SQL Server instance

 2) Open the schema file - Database/schema.sql

 3) Execute the script
 
 4) Verify :- Databases → UserDataDB → Tables → dbo.Users



 ### Step 3: Configure Connection String

 Update appsettings.json
 ```bash
 {
  "ConnectionStrings": {
    "LiquidLabsConnectionString": "Server=LAPTOP-LLFF25ML\\SQLEXPRESS;Database=UserDataDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

 ### Step 4: Build and Run

 Using Visual Studio

    Open LiquidLabs.API.sln

    Press F5

    Swagger UI opens automatically

 ## Application URLs

 HTTPS: https://localhost:7109

 HTTP: http://localhost:5164

 Swagger UI: https://localhost:7109/swagger



 ## API Endpoints

 ```bash
 https://localhost:7109/api
```

 #### Get All Users
 Fetches all users. Retrieves from database if cached, otherwise fetches from JSONPlaceholder and stores locally.
 ```bash
 GET /api/users
 ```

  #### Get User by ID
 Retrieves a single user by ID. Checks cache first.
 ```bash
 GET /api/users/{id}
 ```


 ## Testing the API

 Using Swagger UI

    Run the application

    Open https://localhost:7109/swagger

    Click Try it out

    Execute and view response


 ## Author

#### Hizbullah