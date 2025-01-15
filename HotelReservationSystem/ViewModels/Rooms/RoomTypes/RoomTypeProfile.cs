// using AutoMapper;
// using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;
//
// namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
// {
//     public class RoomTypeProfile : Profile
//     {
//         public RoomTypeProfile()
//         {
//
//             CreateMap<RType, RoomTypeViewModel>()
//            .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src =>
//                src.RTypeFacilities.Select(rtf => rtf).ToList()));
//
//             CreateMap<CreateRoomTypeViewModel, AddRoomTypeCommand>();
//             CreateMap<UpdateRoomTypeViewModel, UpdateRoomTypeCommand>();
//             CreateMap<UpdateRoomTypeCommand, RType>();
//
//             CreateMap<Facility, RoomTypeViewModel>();
//             CreateMap<DeleteRoomTypeCommand, RType>()
//                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.typeName)) // Map typeName to the Name property
//                         .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Ignore properties you will set manually
//                         .ForMember(dest => dest.Deleted, opt => opt.Ignore());
//         }
//     }
//
// }
