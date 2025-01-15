namespace HotelReservationSystem.Models.RoomManagement
{
    public class RType : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Room> Rooms { get; set; } = default!;
        public ICollection<RTypeFacility> RTypeFacilities { get; set; } = new List<RTypeFacility>();

    }
}
