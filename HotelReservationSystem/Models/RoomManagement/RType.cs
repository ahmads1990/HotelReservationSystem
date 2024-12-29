

namespace HotelReservationSystem.Models.RoomManagement
{
    public class RType : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<RTypeFacilities> RTypeFacilities { get; set; }  = new List<RTypeFacilities>();
        
    }
}
