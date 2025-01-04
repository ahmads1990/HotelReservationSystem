namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomType : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Room> Rooms { get; set; } = default!;
        public ICollection<RoomTypeFacility> RoomTypeFacilities { get; set; }  = new List<RoomTypeFacility>();
        
    }
}
