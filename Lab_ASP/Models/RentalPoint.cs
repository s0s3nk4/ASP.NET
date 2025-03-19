using System.ComponentModel.DataAnnotations;

namespace Lab_ASP.Models
{
    public class RentalPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
