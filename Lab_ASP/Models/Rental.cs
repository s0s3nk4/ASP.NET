using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_ASP.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public Equipment Equipment { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public bool IsReturned => EndDate.HasValue;
    }
}
