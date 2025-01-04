using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries.GetAllRoom
{
    public class GetAllRoomTypeDto
    {
        public RoomTypeName RoomTypeName { get; set; }
        public double Price { get; set; }
    }
}
