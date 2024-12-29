using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.RoomFacilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public List<RoomTypeViewModel> Facilities { get; set; }
        public List<RoomTypeViewModel> CustomFacilities { get; set; }
    }
}
