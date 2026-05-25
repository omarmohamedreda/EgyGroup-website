# Egygroup Website
 
A bilingual **(Arabic / English)** company website built with **ASP.NET Core MVC**, featuring a product catalogue, brand management, and a protected admin dashboard.
 
---
 
## 🏗️ Solution Structure
 
```
Egygroup.sln
├── Egygroup.DAL   → Data Access Layer  (Models, DbContext, Repositories, UoW)
├── Egygroup.BLL   → Business Logic Layer  (Services, DTOs)
└── Egygroup.PL    → Presentation Layer  (Controllers, ViewModels, Views)
```
 
---
 
## ✨ Features
 
- 🌐 **Arabic & English** localization with RTL/LTR layout switching
- 🏷️ **Brand & Product** catalogue with bilingual names and descriptions
- 🔐 **ASP.NET Core Identity** — login, register, roles
- 🛡️ **Admin dashboard** (brands CRUD, products CRUD) protected by `[Authorize(Roles = "Admin")]`
- 📁 **File upload** for brand logos and product images
- 🌱 **Admin user seeded** automatically on first run
- ⚙️ **Generic Repository + Unit of Work** pattern
---
 
 


 
## 🌍 Localization
 
- Static UI strings → `.resx` files under `PL/Resources/`
- Dynamic content (brands, products) → `NameEn` / `NameAr` columns in the database
- Language is persisted in a **cookie** and toggled via a navbar dropdown
- Bootstrap RTL stylesheet is loaded automatically for Arabic
---
 
## 🛠️ Tech Stack
 
- **ASP.NET Core 8 MVC**
- **Entity Framework Core** (Code-First, SQL Server)
- **ASP.NET Core Identity**
- **Bootstrap 5** (+ RTL variant)
- **C# 12**
