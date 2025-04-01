using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_ASP.Models.ViewModels
{
    public class EquipmentDetailViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public string? ImgURL { get; set; }
        [Required]
        public int EquipmentTypeId { get; set; }
        [Required]
        public int RentalPointId { get; set; }
    }
}
