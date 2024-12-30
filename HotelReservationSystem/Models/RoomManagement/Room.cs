namespace HotelReservationSystem.Models.RoomManagement
{
    public class Room : BaseModel
    {
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        public ICollection<RoomFacilities> RoomFacilities { get; set; } = new List<RoomFacilities>();
    }
}
