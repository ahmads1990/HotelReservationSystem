using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;


namespace HotelReservationSystem.Features.ReservationManagement.AddReservation;

public class ReservationCreateRequestViewModel
{
    public string SpecialRequests { get; set; }
    public double TotalAmount { get; set; }
    public string MainGuestNID { get; set; }
    public List<ReservationRoomCreateRequestViewModel> ReservationRooms { get; set; }
} 