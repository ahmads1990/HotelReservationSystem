using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;

public class ReservationDTO
{
    public int ID { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public double SpecialRequests { get; set; }
    public decimal TotalAmount { get; set; }
    public List<Guest> Guests { get; set; }
    public List<string> RoomNumbers { get; set; }
}