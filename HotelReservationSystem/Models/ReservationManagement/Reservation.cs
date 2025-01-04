using HotelReservationSystem.Models.PaymentManagement;

namespace HotelReservationSystem.Models.ReservationManagement;

public class Reservation : BaseModel
{
    public int ReservationID { get; set; }
    public string GuestName { get; set; }
    public string ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequests { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ContactDetails { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalAmountPaid { get; set; }
    public ICollection<ReservationRoom> ReservationRooms { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
