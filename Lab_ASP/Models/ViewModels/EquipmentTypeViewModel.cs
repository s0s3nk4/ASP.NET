using System.ComponentModel.DataAnnotations;

namespace Lab_ASP.Models.ViewModels
{
    public class EquipmentTypeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa typu sprzętu jest wymagana")]
        public string? Name { get; set; }
    }
}
