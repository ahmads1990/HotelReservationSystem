using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.ViewModels.RoomManagment.RTypes
{
    public class CreateRoomTypeViewModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
