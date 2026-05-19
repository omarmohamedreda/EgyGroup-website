using Egygroup.BLL.Services;
using Egygroup.DAL.Contexts;
using Egygroup.DAL.Models;
using Egygroup.DAL.UnitOfWork;
using Egygroup.PL.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC05_MVC06.DAL.Models.Auth;

namespace Egygroup.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MVC
            builder.Services.AddControllersWithViews();

            // DB Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // DAL
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // BLL
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // Cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/access-denied";
            });


            // Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en", "ar" };
                options.SetDefaultCulture("en")
                       .AddSupportedCultures(supportedCultures)
                       .AddSupportedUICultures(supportedCultures);
            });


            // =====================
            var app = builder.Build();
            // =====================

            // Seed Admin
            using (var scope = app.Services.CreateScope())
            {
                await AdminSeeder.SeedAsync(scope.ServiceProvider);
            }

            // Middleware Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseRequestLocalization();

            app.UseAuthentication();   
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}