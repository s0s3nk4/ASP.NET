using System.ComponentModel.DataAnnotations;

namespace Lab_ASP.Models
{
    public class RentalPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
