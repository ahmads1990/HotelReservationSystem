using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class CreateRoomViewModel
    {
        public int ID { get; set; }
        public RoomTypeName RoomTypeName { get; set; }
        public List<FacilityViewModel> Facilities { get; set; }
    }
}
