using AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class AddRoomProfile : Profile
    {
        public AddRoomProfile()
        {
            CreateMap<Room, RoomViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities));

            CreateMap<AddRoomRequestViewModel, AddRoomCommand>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.RoomTypeID, opt => opt.MapFrom(src => src.RoomTypeID));

            CreateMap<Room, RoomViewModel>();
        }
    }

}
