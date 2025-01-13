using HotelReservationSystem.Models.ReservationManagement;

namespace HotelReservationSystem.Models.RoomManagement
{
    public class Room : BaseModel
    {
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        public ICollection<RoomFacility> RoomFacilities { get; set; } = new List<RoomFacility>();
        public ICollection<ReservationRoom> ReservationRooms { get; set; } = new List<ReservationRoom>();
    }
}
