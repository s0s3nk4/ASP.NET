using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_ASP.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public Equipment? Equipment { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
