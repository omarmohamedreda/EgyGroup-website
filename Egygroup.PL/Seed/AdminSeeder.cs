using Egygroup.DAL.Models;
using Microsoft.AspNetCore.Identity;
using MVC05_MVC06.DAL.Models.Auth;

namespace Egygroup.PL.Seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // 1. Create Admin role if not exists
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            // 2. Create admin user if not exists
            const string adminEmail = "admin@egygroup.com";
            const string adminPassword = "Admin@1234";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, adminPassword);
            }

            // 3. Assign Admin role
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}