namespace HotelReservationSystem.Models.RoomManagement
{
    public class Room : BaseModel
    {
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        // Facilities specific to this room
        public ICollection<RoomFacility> CustomFacilities { get; set; } = new List<RoomFacility>();
    }
}
