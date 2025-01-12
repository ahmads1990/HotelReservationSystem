using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;
using HotelReservationSystem.Features.ReservationManagement.AddReservation;
using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;
using HotelReservationSystem.ViewModels.reservationRooms;

namespace HotelReservationSystem.ViewModels.Reservations;

public class ReservationCreateRequestViewModel
{
    public string SpecialRequests { get; set; }
    public double TotalAmount { get; set; }
    public List<ReservationRoomCreateRequestViewModel> Guests { get; set; }
}