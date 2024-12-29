using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.RoomFacilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public List<RoomFacilityViewModel> Facilities { get; set; }
    }
}
