using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.ViewModels.Reservations;

public class ReservationViewModel
{
    public ReservationStatus ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequests { get; set; }
    public decimal TotalAmount { get; set; }
    public List<Guest> Guests { get; set; }
    public List<string> RoomNumbers { get; set; }
}