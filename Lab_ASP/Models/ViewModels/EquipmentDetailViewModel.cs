using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_ASP.Models.ViewModels
{
    public class EquipmentDetailViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka jest wymagana")]
        [StringLength(50, ErrorMessage = "Marka nie może być dłuższa niż 50 znaków")]
        public string? Make { get; set; }
        [Required(ErrorMessage = "Model jest wymagany")]
        [StringLength(50, ErrorMessage = "Model nie może być dłuższy niż 50 znaków")]
        public string? Model { get; set; }
        [Required(ErrorMessage = "Rok produkcji jest wymagany")]
        [Range(2015, 2025, ErrorMessage = "Rok produkcji musi być z przedziału 2015-2025")]
        public int Year { get; set; }
        public string? Description { get; set; }
        public string? ImgURL { get; set; }
        [Required(ErrorMessage = "Typ sprzętu jest wymagany")]
        public int EquipmentTypeId { get; set; }
        [Required(ErrorMessage = "Punkt wypożyczeń jest wymagany")]
        public int RentalPointId { get; set; }
    }
}
