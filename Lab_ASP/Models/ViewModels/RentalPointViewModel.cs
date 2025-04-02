using System.ComponentModel.DataAnnotations;

namespace Lab_ASP.Models.ViewModels
{
    public class RentalPointViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa punktu wypożyczeń jest wymagana")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Adres punktu wypożyczeń jest wymagany")]
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
