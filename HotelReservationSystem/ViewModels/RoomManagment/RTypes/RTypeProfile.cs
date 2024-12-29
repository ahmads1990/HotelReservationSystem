using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
{
    public class RTypeProfile : Profile
    {
        public RTypeProfile()
        {
            
            CreateMap<RType, RTypeViewModel>()
           .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
               src.RTypeFacilities.Select(rtf => rtf).ToList()));

            CreateMap<Facility, RTypeViewModel>();
        }
    }

}
