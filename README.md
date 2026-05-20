# 🛒 CommerceCore API

A modern, scalable, and production-ready eCommerce backend built with **ASP.NET Core** and **Clean Architecture** principles.

This project provides a complete foundation for building powerful eCommerce platforms, including authentication, product management, order processing, shopping carts, and advanced administrative management through role-based permissions.

---

# ✨ Features

- 🔐 JWT Authentication & Authorization
- 👨‍💼 Multi-Role Administrative System
- 🛡️ Permission-Based Access Control
- 📦 Product & Category Management
- 🛒 Shopping Cart System
- 📑 Order Processing
- 💳 Payment Integration Ready
- ❤️ Wishlist Support
- 🔎 Filtering, Pagination & Search
- 📁 Clean Architecture Structure
- 🧩 Repository & Service Pattern
- 📡 RESTful API Design
- 🧪 Swagger/OpenAPI Documentation
- 🗄️ Entity Framework Core Integration
- ⚡ Scalable & Maintainable Architecture
- 🐳 Docker Ready
- ☁️ Cloud Deployment Friendly

---

# 👨‍💼 Administrative Roles

The platform supports multiple administrator roles with customizable permissions.

Examples include:

- Super Admin
- Product Manager
- Order Manager
- Content Manager
- Support Administrator

Each role can have specific access privileges to different modules and operations inside the system.

---

# 🏗️ Architecture

The project follows **Clean Architecture** principles to ensure:

- Scalability
- Maintainability
- Separation of Concerns
- Testability

### Project Structure

```bash
src/
├── Core/            # Domain entities & business rules
├── Application/     # Business logic & use cases
├── Infrastructure/  # Database & external services
├── API/             # REST API endpoints
