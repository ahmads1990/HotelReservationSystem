namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;

public class AvailableRoomTypesInPriceRangeDTO
{
    public int ID { get; set; }
    public int RoomTypeID { get; set; }
    public string RoomTypeName { get; set; }
    public double BasicPrice { get; set; }
}