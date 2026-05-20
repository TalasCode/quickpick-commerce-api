# QuickPick Commerce API

A scalable ASP.NET Core Web API backend for an e-commerce platform featuring authentication, role-based authorization, product management, shopping workflows, and administrative controls.

Built with a layered architecture using .NET 8, Entity Framework Core, and SQL Server.

---

## Features

### Authentication & Security

* JWT authentication
* Role-based access control
* Custom route permission middleware
* User and role management

### Product Management

* Categories
* Brands
* Items
* Offers
* Coupons

### Commerce Features

* Shopping cart
* Wishlist
* Orders
* Order items
* Product reviews

### API Features

* RESTful API architecture
* Swagger documentation
* Layered service structure
* Entity Framework Core integration

---

## Architecture

```text
Client Applications
        ↓
ASP.NET Core Controllers
        ↓
Service Layer
        ↓
Repositories + Unit of Work
        ↓
Entity Framework Core
        ↓
SQL Server
```

---

## Tech Stack

* ASP.NET Core Web API (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper
* Swagger / OpenAPI

---

## Project Structure

```text
QuickPick-Commerce-API/

├── eCommerceAPI
│   ├── Controllers
│   ├── Request Models
│   ├── AutoMapper
│
├── eCommerceAPI.Core
│   ├── Models
│   ├── DbContext
│   ├── Repositories
│   ├── DTOs
│
├── eCommerce.Service
│   ├── Business Logic
│   ├── Authentication
│   ├── Permission Middleware
```

---

## Main API Modules

* Authentication
* Users
* Roles
* Permissions
* Categories
* Brands
* Products
* Coupons
* Cart
* Wishlist
* Orders
* Reviews

---

## Getting Started

Clone the repository:

```bash
git clone <repo-url>
```

Restore dependencies:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

Run:

```bash
dotnet run
```

Open Swagger:

```text
https://localhost:7274/swagger
```

---

## Future Improvements

* Password hashing implementation
* Automated testing
* Docker support
* Payment integration
* Database migrations
* Standardized API responses

---

## Why I built this

This project was built to strengthen backend engineering skills around authentication, API design, layered architecture, and building real-world commerce workflows.
