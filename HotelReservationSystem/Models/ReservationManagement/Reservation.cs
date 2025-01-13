using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.PaymentManagement;

namespace HotelReservationSystem.Models.ReservationManagement;

public class Reservation : BaseModel
{
    public ReservationStatus ReservationStatus { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequirements { get; set; }
    public double TotalAmount { get; set; }
    public int GuestID { get; set; }
    public Guest Guest { get; set; }
    public ICollection<ReservationRoom> ReservationRooms { get; set; }
}
 