namespace Lab_ASP.Models.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string? Equipment { get; set; }
        public string? Customer { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
