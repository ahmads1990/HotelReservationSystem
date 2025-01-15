using HotelReservationSystem.Features.GuestManagement.AddGuest;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;

public class ReservationRoomCreateRequestViewModel
{
    public int ID { get; set; }
    public int RoomID { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double Amount { get; set; }
    
    public List<GuestCreateRequestViewModel> Guests { get; set; }
}