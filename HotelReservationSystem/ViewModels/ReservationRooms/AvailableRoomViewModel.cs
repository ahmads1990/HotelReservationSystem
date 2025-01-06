using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.ViewModels.reservationRooms;

public class AvailableRoomViewModel
{
    public int RoomID { get; set; }
    public string RoomType { get; set; }
    public string RoomNumber { get; set; }
    public double? BasicPrice { get; set; }
    
    public IEnumerable<FacilityViewModel> Facilities { get; set; }
}