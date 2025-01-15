namespace HotelReservationSystem.Models.RoomManagement
{
    public class RTypeFacility : BaseModel
    {
        public int RTypeID { get; set; }
        public RType RType { get; set; }

        public int FacilityID { get; set; }
        public Facility Facility { get; set; }
    }
}
