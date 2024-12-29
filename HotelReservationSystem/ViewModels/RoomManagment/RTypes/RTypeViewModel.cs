namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
{
    public class RTypeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RTypeViewModel> Facilities { get; set; }
    }
}
