namespace HotelReservationSystem.Models.RoomManagement
{
    public class RTypeFacilities
    {
        public int ID { get; set; }
        public int RTypeID { get; set; }
        public RType RType { get; set; }

        public int FacilityID { get; set; }
        public Facility Facility { get; set; }
    }
}
