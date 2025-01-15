using AutoMapper;
using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;
using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.ViewModels.Reservations;

public class AddReservationVMProfile : Profile
{
    public AddReservationVMProfile()
    {
        
        CreateMap<ReservationRoomCreateRequestViewModel, AddReservationCommand>();
        CreateMap<AddReservationCommand, Reservation>();
        CreateMap<ReservationRoomCreateRequestViewModel, AddReservationOrchestrator>();
    }
}
