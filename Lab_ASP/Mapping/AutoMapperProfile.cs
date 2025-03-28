using AutoMapper;
using Lab_ASP.Models;
using Lab_ASP.Models.ViewModels;

namespace Lab_ASP.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Equipment, EquipmentItemViewModel>().ReverseMap();
            CreateMap<Equipment, EquipmentDetailViewModel>().ReverseMap();

            CreateMap<Equipment, EquipmentsItemViewModel>().ReverseMap();
            CreateMap<Equipment, EquipmentsDetailViewModel>().ReverseMap();

            CreateMap<RentalPoint, RentalPointItemViewModel>().ReverseMap();
            CreateMap<RentalPoint, RentalPointDetailViewModel>().ReverseMap();
        }
    }
}
