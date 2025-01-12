using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;

public class AvailableRoomDTO
{
    public int RoomID { get; set; }
    public string RoomType { get; set; }
    public string RoomNumber { get; set; }
    public double? BasicPrice { get; set; }
    
    public IEnumerable<FacilityViewModel> Facilities { get; set; }
}