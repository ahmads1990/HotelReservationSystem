using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.RoomFacilities
{
    public class RoomFacilityProfile : Profile
    {
        public RoomFacilityProfile()
        {
            CreateMap<Facility, RoomFacilityViewModel>().ReverseMap();
                
        }
    }

}
