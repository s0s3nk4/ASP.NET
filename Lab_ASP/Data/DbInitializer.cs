using Lab_ASP.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace Lab_ASP.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManaegr = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "User", "Operator" };

            foreach(var role in roleNames)
            {
                if(!await roleManaegr.RoleExistsAsync(role))
                {
                    await roleManaegr.CreateAsync(new IdentityRole(role));
                }
            }

            string adminEmail = "admin@example.com";
            string adminPassword = "Admin123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "System",
                    UserType = UserType.Gold
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
