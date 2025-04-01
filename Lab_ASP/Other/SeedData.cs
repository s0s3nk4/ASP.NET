using Lab_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.EquipmentsType.Any())
                {
                    return;
                }

                var bikeType = new EquipmetType
                {
                    Name = "Bike"
                };
                var scooterType = new EquipmetType
                {
                    Name = "Scooter"
                };

                context.EquipmentsType.AddRange(bikeType, scooterType);
                context.SaveChanges();

                var rentalPoint = new RentalPoint
                {
                    Name = "Wypożyczlania UBB",
                    Address = "Willowa 2"
                };
                context.RentalPoints.Add(rentalPoint);
                context.SaveChanges();

                context.Equipments.Add(new Equipment
                {
                    Make = "Romet",
                    Model = "Jaguar",
                    Year = 2025,
                    Description = "Każdy takiego chciał",
                    ImageURL = "/images/bike.jpg",
                    EquipmentTypeId = bikeType.Id,
                    RentalPointId = rentalPoint.Id
                });
                
                context.SaveChanges();
            }
        }
    }
}
