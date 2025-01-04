using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.Models.PaymentManagement;

public class Payment : BaseModel
{
    public int ReservationID { get; set; }
    public Reservation Reservation { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentStatus { get; set; }
}