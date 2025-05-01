using Lab_ASP.Data;
using Lab_ASP.Repositories;
using Lab_ASP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lab_ASP.Mappings;
using Lab_ASP.Validators;
using FluentValidation;
using Lab_ASP.Models.ViewModels;
using Lab_ASP.Models;
using FluentValidation.AspNetCore;

namespace Lab_ASP;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure database
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
        //UseSqlServer(connectionString));
        //UseInMemoryDatabase("InMemoryDb"));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // Configure identity
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        // Configure services
        builder.Services.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservationValidator>());
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        // Configure routes
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        // Ensure database is created
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
        }

        using (var scope = app.Services.CreateScope())
        {
            /*var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, "Admin1234!");
            }*/
            var services = scope.ServiceProvider;
            await DbInitializer.SeedRolesAndAdminAsync(services);
        }


        app.Run();
    }
}
