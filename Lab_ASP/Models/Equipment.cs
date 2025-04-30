using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Lab_ASP.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }
        public string? Description { get; set; }
        public string? ImgURL { get; set; }
        [ForeignKey("EquipmentTypeId")]
        public int EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; }
        [ForeignKey("RentalPointId")]
        public int RentalPointId { get; set; }
        public RentalPoint? RentalPoint { get; set; }
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
