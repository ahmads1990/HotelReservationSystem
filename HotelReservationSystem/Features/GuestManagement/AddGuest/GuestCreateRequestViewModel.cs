namespace HotelReservationSystem.Features.GuestManagement.AddGuest;

public class GuestCreateRequestViewModel
{
    public string Name { get; set; } = string.Empty;
    public string NID { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
    
    public bool IsVIP { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public bool IsMainGuest { get; set; }
}