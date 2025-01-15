using AutoMapper;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;
using HotelReservationSystem.Models.RoomManagement;

namespace HotelReservationSystem.ViewModels.RoomManagment.Facilities
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility, FacilityDTO>().ReverseMap();

        }
    }

}
