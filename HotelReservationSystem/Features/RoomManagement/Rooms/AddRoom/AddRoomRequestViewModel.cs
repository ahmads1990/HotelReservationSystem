namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class AddRoomRequestViewModel
    {
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomTypeID { get; set; }
        public List<int> RoomFacilities { get; set; }
    }
}
