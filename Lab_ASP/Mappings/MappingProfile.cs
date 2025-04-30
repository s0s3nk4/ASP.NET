using AutoMapper;
using Lab_ASP.Models;
using Lab_ASP.Models.ViewModels;

namespace Lab_ASP.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentItemViewModel>()
            .ForMember(dest => dest.EquipmentType, opt => opt.MapFrom(src => src.EquipmentType.Name ))
            .ForMember(dest => dest.RentalPoint, opt => opt.MapFrom(src => src.RentalPoint.Address ))
            .ReverseMap();

            CreateMap<Equipment, EquipmentDetailViewModel>()
                .ForMember(dest => dest.EquipmentType, opt => opt.MapFrom(src => src.EquipmentType != null ? src.EquipmentType.Name : "Brak kategorii"))
            .ForMember(dest => dest.RentalPoint, opt => opt.MapFrom(src => src.RentalPoint != null ? src.RentalPoint.Address : "Brak adresu"))
                .ReverseMap();

            CreateMap<EquipmentType, EquipmentTypeViewModel>().ReverseMap();

            CreateMap<RentalPoint, RentalPointViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationViewModel>().ReverseMap();

            CreateMap<Rental, RentalViewModel>().ReverseMap();
        }
    }
}
