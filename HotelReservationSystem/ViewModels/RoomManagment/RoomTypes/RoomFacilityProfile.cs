using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.RoomTypes
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomType, RoomTypeViewModel>().ReverseMap();
        }
    }

}
