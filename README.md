# QuickPick Commerce API

A scalable ASP.NET Core Web API backend powering an e-commerce platform with authentication, role-based authorization, product management, and commerce workflows.

Built using a layered architecture with .NET 8, Entity Framework Core, SQL Server, and JWT authentication.

---

## Features

### Authentication & Security

* JWT authentication
* Role-based access control (RBAC)
* Custom permission middleware
* User and role management

### Product Management

* Categories
* Brands
* Products
* Offers
* Coupons

### Commerce Workflows

* Shopping cart
* Wishlist
* Orders and order items
* Product reviews

### Backend Architecture

* RESTful API design
* Swagger/OpenAPI documentation
* Layered architecture
* Repository + Unit of Work pattern
* Entity Framework Core integration

---

## Architecture

```text
Client Applications
        ↓
ASP.NET Controllers
        ↓
Service Layer
        ↓
Repositories + Unit Of Work
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

├── eCommerceAPI.Core
│   ├── Models
│   ├── DbContext
│   ├── Repositories
│   ├── DTOs

├── eCommerce.Service
│   ├── Business Logic
│   ├── Authentication
│   ├── Permission Middleware
```

---

## Core Modules

* Authentication
* Users
* Roles
* Permissions
* Products
* Categories
* Brands
* Coupons
* Cart
* Wishlist
* Orders
* Reviews

---

## Getting Started

Clone repository:

```bash
git clone <repo-url>
```

Install dependencies:

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

Swagger:

```text
https://localhost:7274/swagger
```

---

## Future Improvements

* Password hashing
* Docker support
* Automated testing
* Payment integration
* Database migrations
* Standardized API responses

---

## Why I built this

This project was built to strengthen backend engineering skills around API design, authentication, layered architectures, and real-world commerce workflows.
