using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.PaymentManagement;

namespace HotelReservationSystem.Models.ReservationManagement;

public class Reservation : BaseModel
{
    public ReservationStatus ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequests { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal TotalAmountPaid { get; set; }
    public int GuestId { get; set; }
    public ICollection<ReservationRoom> ReservationRooms { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
