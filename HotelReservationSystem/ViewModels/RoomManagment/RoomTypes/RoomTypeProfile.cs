using AutoMapper;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;

namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            
            CreateMap<RoomType, RoomTypeViewModel>()
           .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
               src.RoomTypeFacilities.Select(rtf => rtf).ToList()));

            CreateMap<UpdateRoomTypeViewModel, UpdateRoomTypeCommand>();
            CreateMap<UpdateRoomTypeCommand, RoomType>();

            CreateMap<Facility, RoomTypeViewModel>();
        }
    }

}
