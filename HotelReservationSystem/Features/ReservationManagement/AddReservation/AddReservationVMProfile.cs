using AutoMapper;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;
using HotelReservationSystem.Features.GuestManagement.AddListOfGuests;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.Models.ReservationManagement;
using HotelReservationSystem.ViewModels.reservationRooms;

namespace HotelReservationSystem.ViewModels.Reservations;

public class AddReservationVMProfile : Profile
{
    public AddReservationVMProfile()
    {
        CreateMap<GuestCreateRerquestViewModel, GuestCreateDTO>();
        CreateMap<ReservationRoomCreateRequestViewModel, AddReservationCommand>();
        CreateMap<AddReservationCommand, Reservation>();
        CreateMap<ReservationRoomCreateRequestViewModel, AddReservationOrchestrator>();
    }
}
