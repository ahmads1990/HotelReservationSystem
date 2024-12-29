namespace HotelReservationSystem.ViewModels.RoomManagment
{
    public class RoomTypeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RoomTypeViewModel> Facilities { get; set; }
    }
}
