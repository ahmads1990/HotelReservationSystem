namespace HotelReservationSystem.Models.RoomManagement
{
    public class Facility : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<RTypeFacility> RTypeFacilities { get; set; } = new List<RTypeFacility>();



    }
}
