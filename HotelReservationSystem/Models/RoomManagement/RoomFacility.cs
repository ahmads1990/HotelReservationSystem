namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomFacility: BaseModel
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int FacilityID { get; set; }
        public Facility Facility { get; set; }
    }
}
