namespace Lab_ASP.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public int ID { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public string? ImgURL { get; set; }
        public string Type { get; set; }
        public List<EquipmentTypeViewModel>? Types { get; set; }
        public string? RentalPoint { get; set; }
        public List<RentalPointViewModel>? RentalPoints { get; set; }
    }
}
