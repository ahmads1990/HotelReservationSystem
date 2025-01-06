namespace HotelReservationSystem.DTOs.Guests;

public class GuestCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public string NID { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
}