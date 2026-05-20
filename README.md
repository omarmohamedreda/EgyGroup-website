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
 
## 🗄️ Database Models
 
| Model | Key Fields |
|-------|-----------|
| `Brand` | `Id`, `NameEn`, `NameAr`, `LogoUrl`, `DescriptionEn`, `DescriptionAr` |
| `Product` | `Id`, `NameEn`, `NameAr`, `DescriptionEn`, `DescriptionAr`, `ImageUrl`, `IsActive`, `BrandId` |
| `ApplicationUser` | Extends `IdentityUser` with `FirstName`, `LastName` |
 
---
 
## 🚀 Getting Started
 
### Prerequisites
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code
### Setup
 
1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/egygroup.git
   cd egygroup
   ```
 
2. **Update the connection string** in `Egygroup.PL/appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=EgygroupDb;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```
 
3. **Apply migrations**
   ```bash
   # In Package Manager Console (default project: Egygroup.DAL)
   Update-Database
 
   # Or via CLI
   dotnet ef database update --project Egygroup.DAL --startup-project Egygroup.PL
   ```
 
4. **Run the application**
   ```bash
   dotnet run --project Egygroup.PL
   ```
 
The admin user is seeded automatically on first run:
 
| Field | Value |
|-------|-------|
| Email | `admin@egygroup.com` |
| Password | `Admin@123` |
| Role | `Admin` |
 
---
 
## 📄 Pages & Routes
 
| Page | URL | Access |
|------|-----|--------|
| Home | `/en` or `/ar` | Public |
| Products | `/en/products` | Public |
| Products by Brand | `/en/products/brand/{id}` | Public |
| Product Details | `/en/products/{id}` | Public |
| About | `/en/about` | Public |
| Admin — Brands | `/admin/brands` | Admin only |
| Admin — Products | `/admin/products` | Admin only |
| Login | `/account/login` | Public |
| Register | `/account/register` | Public |
 
---
 
## 🏛️ Architecture
 
```
Request
  └── Controller (PL)
        └── Service (BLL)
              └── UnitOfWork → GenericRepository (DAL)
                                    └── AppDbContext (EF Core)
```
 
- **DAL** — `IGenericRepository<T>` / `GenericRepository<T>`, `IUnitOfWork` / `UnitOfWork`
- **BLL** — `IBrandService` / `BrandService`, `IProductService` / `ProductService`, DTOs
- **PL** — Controllers, ViewModels (with DataAnnotations), Razor Views, file upload helpers
---
 
## 🌍 Localization
 
- Static UI strings → `.resx` files under `PL/Resources/`
- Dynamic content (brands, products) → `NameEn` / `NameAr` columns in the database
- Language is persisted in a **cookie** and toggled via a navbar dropdown
- Bootstrap RTL stylesheet is loaded automatically for Arabic
---
 
## 📁 Project Structure (PL)
 
```
Egygroup.PL/
├── Controllers/
│   ├── Admin/
│   │   ├── AdminBrandsController.cs
│   │   └── AdminProductsController.cs
│   ├── AccountController.cs
│   └── LanguageController.cs
├── ViewModels/
│   ├── BrandViewModel.cs
│   ├── ProductViewModel.cs
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _AdminLayout.cshtml
│   ├── AdminBrands/
│   ├── AdminProducts/
│   └── Account/
├── Resources/
│   ├── SharedResource.en.resx
│   └── SharedResource.ar.resx
├── Seed/
│   └── AdminSeeder.cs
└── wwwroot/
    ├── css/
    ├── js/
    └── uploads/
```
 
---
 
## 🔜 Roadmap
 
- [ ] Public pages (Home, Products, About) with full styling
- [ ] Complete `.resx` translation files
- [ ] UI polish (Bootstrap 5 + custom CSS)
---
 
## 🛠️ Tech Stack
 
- **ASP.NET Core 8 MVC**
- **Entity Framework Core** (Code-First, SQL Server)
- **ASP.NET Core Identity**
- **Bootstrap 5** (+ RTL variant)
- **C# 12**
