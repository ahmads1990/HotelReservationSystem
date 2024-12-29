namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomFacilityAssignment
    {
        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int RoomFacilityID { get; set; }
        public RoomFacility RoomFacility { get; set; }
    }
}
