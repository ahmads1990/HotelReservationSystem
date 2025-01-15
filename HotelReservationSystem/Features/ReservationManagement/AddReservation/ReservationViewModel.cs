using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;
using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation;

public class ReservationViewModel
{
    public ReservationStatus ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public double SpecialRequests { get; set; }
    public decimal TotalAmount { get; set; }
    public List<ReservationRoomViewModel> ReservationRooms { get; set; }
}