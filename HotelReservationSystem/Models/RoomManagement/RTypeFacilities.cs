namespace HotelReservationSystem.Models.RoomManagement
{
    public class RTypeFacilities
    {
        public int RoomTypeId { get; set; }
        public RType RoomType { get; set; }

        public int RoomFacilityId { get; set; }
        public Facility RoomFacility { get; set; }
    }
}
