namespace HotelReservationSystem.Models.RoomManagement
{
    public class Room : BaseModel
    {
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
        public RType RoomType { get; set; }

        public ICollection<RoomFacilities> RoomFacilities { get; set; } = new List<RoomFacilities>();
    }
}
