using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomFacilityProfile : Profile
    {
        public RoomFacilityProfile()
        {
            CreateMap<Room, RoomViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomType.RoomFacilities.Concat(src.CustomFacilities)))
                .ForMember(dest => dest.CustomFacilities, opt => opt.MapFrom(src => src.CustomFacilities));
        }
    }

}
