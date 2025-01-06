using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;
using HotelReservationSystem.ViewModels.Guests;
using HotelReservationSystem.ViewModels.reservationRooms;

namespace HotelReservationSystem.ViewModels.Reservations;

public class ReservationCreateViewModel
{
    public string SpecialRequests { get; set; }
    public double TotalAmount { get; set; }
    public List<ReservationRoomCreateViewModel> Guests { get; set; }
}