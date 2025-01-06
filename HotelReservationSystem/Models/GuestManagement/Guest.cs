namespace HotelReservationSystem.Models.GuestManagement;

public class Guest : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NID { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
}