using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_ASP.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int EquipmentTypeId { get; set; }
        [ForeignKey("EquipmentTypeId")]
        public EquipmetType EquipmentType { get; set; }

        public int RentalPointId { get; set; }
        public RentalPoint RentalPoint { get; set; }
    }
}
