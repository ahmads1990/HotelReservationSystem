using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            
            CreateMap<RoomType, RoomTypeViewModel>()
           .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
               src.RoomTypeFacilities.Select(rtf => rtf).ToList()));

            CreateMap<Facility, RoomTypeViewModel>();
        }
    }

}
