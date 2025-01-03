
namespace HotelReservationSystem.Models.Enums;

public enum ErrorCode
{
    None = 0,
    UnKnownError,
    FieldIsEmpty,
    InvalidInput,
    ItemAlreadyExists,


    UserNotFound,
    RoomNotFound,
}
