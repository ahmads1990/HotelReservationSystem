using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.RoomTypes
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomType, RoomTypeViewModel>().ReverseMap();

            CreateMap<RoomType, RoomTypeViewModel>()
           .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
               src.RoomFacilities.Select(rtf => rtf).ToList()));

            CreateMap<RoomFacility, RoomTypeViewModel>();
        }
    }

}
