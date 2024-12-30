using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomType : BaseModel
    {
        public RoomTypeName Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<RoomTypeFacilities> RoomTypeFacilities { get; set; }  = new List<RoomTypeFacilities>();
        
    }
}
