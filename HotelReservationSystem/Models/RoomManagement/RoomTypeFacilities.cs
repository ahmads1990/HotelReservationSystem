namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomTypeFacilities
    {
        public int ID { get; set; }
        public int RTypeID { get; set; }
        public RoomType RType { get; set; }

        public int FacilityID { get; set; }
        public Facility Facility { get; set; }
    }
}
