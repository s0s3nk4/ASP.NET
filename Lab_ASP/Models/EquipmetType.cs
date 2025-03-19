using System.ComponentModel.DataAnnotations;

namespace Lab_ASP.Models
{
    public class EquipmetType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
