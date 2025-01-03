using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Facilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class CreateRoomViewModel
    {
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomTypeID { get; set; }
        public List<int> RoomFacilities { get; set; }
    }
}
