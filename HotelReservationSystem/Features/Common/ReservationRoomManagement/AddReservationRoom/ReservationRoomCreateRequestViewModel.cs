using HotelReservationSystem.Features.GuestManagement.AddListOfGuests;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;

public class ReservationRoomCreateRequestViewModel
{
    public string RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double Amount { get; set; }
    
    public List<GuestCreateRerquestViewModel> Guests { get; set; }
}