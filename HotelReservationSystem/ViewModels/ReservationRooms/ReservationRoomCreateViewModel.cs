using HotelReservationSystem.ViewModels.Guests;

namespace HotelReservationSystem.ViewModels.reservationRooms;

public class ReservationRoomCreateViewModel
{
    public string RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal Amount { get; set; }
    
    public List<GuestCreateViewModel> Guests { get; set; }
}