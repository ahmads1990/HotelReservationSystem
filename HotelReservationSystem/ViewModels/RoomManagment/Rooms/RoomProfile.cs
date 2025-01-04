using AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>()
<<<<<<< HEAD
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities));

=======
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities));

            //CreateMap<Room, RoomViewModel>()
            //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
            //.ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
            //    src.RoomType.RoomTypeFacility.Select(rtf => rtf.RoomFacility)
            //    .Concat(src.RoomFacilityAssignments.Select(rfa => rfa.RoomFacility))
            //    .GroupBy(f => f.Name)
            //    .Select(group => group.First())
            //    .ToList()));
>>>>>>> ff538dde934fb10473c2d11461008bdf586b7e8c
            CreateMap<CreateRoomViewModel, AddRoomCommand>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.RoomTypeID, opt => opt.MapFrom(src => src.RoomTypeID));

            CreateMap<Room, RoomViewModel>();
        }
    }

}
