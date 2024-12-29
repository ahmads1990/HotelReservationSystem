namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomFacilities
    {
        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int RoomFacilityID { get; set; }
        public Facility RoomFacility { get; set; }
    }
}
