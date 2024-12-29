namespace HotelReservationSystem.Models.RoomManagement
{
    public class Room : BaseModel
    {
        public string RoomNumber { get; set; }
        public int RTypeID { get; set; }
        public RType RType { get; set; }

        public ICollection<RoomFacilities> RoomFacilities { get; set; } = new List<RoomFacilities>();
    }
}
