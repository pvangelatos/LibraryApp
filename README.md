# 📚 LibraryApp

A RESTful API for library management built with **ASP.NET Core** and **Clean Architecture**.

## 🏗️ Architecture

The project follows **Clean Architecture** principles, organized in 4 layers:

```
LibraryApp.Domain          → Entities (Book, Member, Loan, User, Role)
LibraryApp.Application     → DTOs, Interfaces, Services, AutoMapper Profiles
LibraryApp.Infrastructure  → DbContext, Repositories, Migrations
LibraryApp.API             → Controllers, Middleware, Program.cs
```

## 🚀 Features

- 📖 **Books** — Full CRUD operations
- 👤 **Members** — Full CRUD operations
- 🔄 **Loans** — Borrow and return books with automatic availability tracking
- 🔐 **JWT Authentication** — Register, Login with role-based authorization
- 👥 **Roles** — Admin, Librarian, Member
- ⚠️ **Global Exception Handler** — Centralized error handling with ProblemDetails (RFC 7807)
- 📝 **Serilog Logging** — Structured logging to console and file
- ✅ **FluentValidation** — Input validation for all DTOs with descriptive error messages

## 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 10 | Web API framework |
| Entity Framework Core 10 | ORM / Code First |
| SQL Server | Database |
| AutoMapper | Object mapping |
| BCrypt.Net | Password hashing |
| JWT Bearer | Authentication |
| Serilog | Logging |
| Swashbuckle (Swagger) | API documentation |
| FluentValidation | Input validation |

## 📋 API Endpoints

### Auth
```
POST /api/auth/register   → Register a new user
POST /api/auth/login      → Login and receive JWT token
```

### Books
```
GET    /api/books         → Get all books
GET    /api/books/{id}    → Get book by ID
POST   /api/books         → Create new book
PUT    /api/books/{id}    → Update book
DELETE /api/books/{id}    → Delete book
```

### Members
```
GET    /api/members       → Get all members
GET    /api/members/{id}  → Get member by ID
POST   /api/members       → Create new member
PUT    /api/members/{id}  → Update member
DELETE /api/members/{id}  → Delete member
```

### Loans
```
GET  /api/loans                        → Get all loans
GET  /api/loans/{id}                   → Get loan by ID
GET  /api/loans/member/{memberId}      → Get loans by member
POST /api/loans                        → Create new loan (borrow book)
PUT  /api/loans/{id}/return            → Return a book
```

## ⚙️ Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server / SQL Server Express
- dotnet-ef tools

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/pvangelatos/LibraryApp.git
cd LibraryApp
```

2. **Configure the connection string**

Edit `LibraryApp.API/appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost\\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Secret": "your-secret-key-at-least-32-characters",
    "Issuer": "https://localhost:7071",
    "Audience": "https://localhost:7071",
    "ExpiryHours": "3"
  }
}
```

3. **Apply migrations**
```bash
dotnet ef database update --project LibraryApp.Infrastructure --startup-project LibraryApp.API
```

4. **Seed the roles** (run in SSMS or Azure Data Studio)
```sql
INSERT INTO Roles (Name) VALUES ('Admin')
INSERT INTO Roles (Name) VALUES ('Librarian')
INSERT INTO Roles (Name) VALUES ('Member')
```

5. **Run the application**
```bash
dotnet run --project LibraryApp.API
```

6. **Open Swagger UI**
```
https://localhost:7071/swagger
```

## 🔐 Authentication

All endpoints (except `/api/auth/register` and `/api/auth/login`) require a valid JWT token.

1. Register a user via `POST /api/auth/register`
2. Login via `POST /api/auth/login` to receive the token
3. Click **Authorize** in Swagger UI and enter: `Bearer {your_token}`

## 📁 Project Structure

```
LibraryApp/
├── LibraryApp.Domain/
│   └── Entities/
│       ├── Book.cs
│       ├── Member.cs
│       ├── Loan.cs
│       ├── User.cs
│       └── Role.cs
├── LibraryApp.Application/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Mappings/
│   └── Services/
├── LibraryApp.Infrastructure/
│   ├── Data/
│   │   ├── Configurations/
│   │   └── LibraryAppDbContext.cs
│   ├── Migrations/
│   └── Repositories/
└── LibraryApp.API/
    ├── Controllers/
    ├── Middleware/
    ├── Program.cs
    └── appsettings.json
```

## 👨‍💻 Author

**Panagiotis Vangelatos**  
Junior .NET Developer  
[LinkedIn](https://linkedin.com/in/panagiotis-vangelatos-71003525a) | [GitHub](https://github.com/pvangelatos)
