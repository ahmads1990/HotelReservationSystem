using AutoMapper;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomFacilityProfile : Profile
    {
        public RoomFacilityProfile()
        {
            CreateMap<Room, RoomViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RType.Name))
                .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities));

            //CreateMap<Room, RoomViewModel>()
            //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name))
            //.ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
            //    src.RoomType.RoomTypeFacilities.Select(rtf => rtf.RoomFacility)
            //    .Concat(src.RoomFacilityAssignments.Select(rfa => rfa.RoomFacility))
            //    .GroupBy(f => f.Name)
            //    .Select(group => group.First())
            //    .ToList()));

            CreateMap<Facility, FacilityViewModel>();
        }
    }

}
