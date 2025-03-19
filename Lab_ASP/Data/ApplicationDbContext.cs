using Lab_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmetType> EquipmentsType { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalPoint> RentalPoints { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Equipment>()
            .HasOne(e => e.EquipmentType)
            .WithMany(et => et.Equipments)
            .HasForeignKey(e => e.EquipmentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EquipmetType>().HasData(
            new EquipmetType { Id = 1, Name = "Bike" },
            new EquipmetType { Id = 2, Name = "Scooter" }
            );

        builder.Entity<Equipment>().HasData(
            new Equipment { Id = 1, Make = "Giant", Model = "Trance 3", Year = 2021, Description = "Mountain bike", ImageURL = "/images/bike.jpg", EquipmentTypeId = 1, RentalPointId = 1 },
            new Equipment { Id = 2, Make = "Xiaomi", Model = "SC2", Year = 2023, Description = "Super scooter", ImageURL = "/images/scooter.jpg", EquipmentTypeId = 2, RentalPointId = 1 }
            );
    }
}
