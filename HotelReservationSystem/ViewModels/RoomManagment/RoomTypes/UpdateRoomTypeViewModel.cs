using HotelReservationSystem.ViewModels.RoomManagment.RTypes;

namespace HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;

public class UpdateRoomTypeViewModel : CreateRoomTypeViewModel
{
    public int ID { get; set; }
    public string Description { get; set; }
}