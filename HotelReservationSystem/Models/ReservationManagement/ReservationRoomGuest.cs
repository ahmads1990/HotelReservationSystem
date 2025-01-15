using HotelReservationSystem.Models.GuestManagement;

namespace HotelReservationSystem.Models.ReservationManagement;

public class ReservationRoomGuest : BaseModel
{
    public int GuestID { get; set; }
    public Guest Guest { get; set; }
    
    public int ReservationRoomID { get; set; }
    public ReservationRoom ReservationRoom { get; set; }

    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    
    public string? SpecialRequirements { get; set; }     
}