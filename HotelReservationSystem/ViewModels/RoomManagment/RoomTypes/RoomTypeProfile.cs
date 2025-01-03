﻿using AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
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
            CreateMap<DeleteRoomTypeCommand, RoomType>()
                        .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.typeName)) // Map typeName to the Name property
                        .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Ignore properties you will set manually
                        .ForMember(dest => dest.Deleted, opt => opt.Ignore());
        }
    }

}
