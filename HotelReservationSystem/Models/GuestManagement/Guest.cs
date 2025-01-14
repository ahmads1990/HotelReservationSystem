using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.Models.GuestManagement;

public class Guest : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NID { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
    public ICollection<ReservationRoomGuest> ReservationRoomGuests { get; set; } = new List<ReservationRoomGuest>();
}