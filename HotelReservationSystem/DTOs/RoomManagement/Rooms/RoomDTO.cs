namespace HotelReservationSystem.DTOs.RoomManagement.Rooms;

public class RoomDTO
{
    public int ID { get; set; }
    public int RoomTypeID { get; set; }
    public string RoomTypeName { get; set; }
    public double BasicPrice { get; set; }
    
}