using AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.RoomTypeName))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities));

            //CreateMap<Room, RoomViewModel>()
            //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
            //.ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
            //    src.RoomType.RoomTypeFacility.Select(rtf => rtf.RoomFacility)
            //    .Concat(src.RoomFacilityAssignments.Select(rfa => rfa.RoomFacility))
            //    .GroupBy(f => f.Name)
            //    .Select(group => group.First())
            //    .ToList()));
            CreateMap<CreateRoomViewModel, AddRoomCommand>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.RoomTypeID, opt => opt.MapFrom(src => src.RoomTypeID));

            CreateMap<Room, RoomViewModel>();
        }
    }

}
