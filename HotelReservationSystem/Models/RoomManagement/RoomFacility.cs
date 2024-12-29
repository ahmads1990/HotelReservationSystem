namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomFacility : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<RoomFacilityAssignment> RoomFacilityAssignments { get; set; }
        public ICollection<RoomTypeFacility> RoomTypeFacilities { get; set; }


    }
}
