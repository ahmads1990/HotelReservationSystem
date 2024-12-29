namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomTypeFacility
    {
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        public int RoomFacilityId { get; set; }
        public RoomFacility RoomFacility { get; set; }
    }
}
