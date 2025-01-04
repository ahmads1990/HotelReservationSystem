using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class UpdateRoomViewModel
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public List<FacilityViewModel> Facilities { get; set; }
    }
}
