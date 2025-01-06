using AutoMapper;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.ViewModels.Guests;
using HotelReservationSystem.ViewModels.reservationRooms;

namespace HotelReservationSystem.ViewModels.Reservations;

public class ReservationVMProfile : Profile
{
    public ReservationVMProfile()
    {
        CreateMap<GuestCreateViewModel, GuestCreateDTO>();
        CreateMap<ReservationRoomCreateViewModel, CreateReservationCommand>();
    }
}
