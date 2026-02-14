# Course Academy API 

A secure Online Courses REST API built using ASP.NET Core Web API.  
Supports role-based access (Admin, Teacher, User) with JWT Authentication and Email Verification.

---

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Authentication
- Swagger

---

## Features

- Secure Authentication with both JWT and Identity
- Role-Based Authorization
- Email Verification
- Course & Category Management
- Enrollment System
- Repository Pattern Implementation
- Progress tracking
- Searching, Filtering, Paging

---

## Setup Instructions

1. Clone the repository
2. Update `appsettings.json`:
   - Set your SQL Server connection string
   - Configure SMTP Email settings
   - Change JWT SigningKey
3. Apply Migrations:
   dotnet ef database update
4. Run the application:
   dotnet run
5. Open Swagger:
   https://localhost:xxxx/swagger

---

## Roles

- Admin: Full system control
- Teacher: Manage Courses
- User: Enroll & View Courses


