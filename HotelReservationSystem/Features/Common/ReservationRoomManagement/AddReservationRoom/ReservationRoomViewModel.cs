namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;

public class ReservationRoomViewModel
{
    public string RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double Amount { get; set; }
    
    public List<string> GuestNames { get; set; }
}