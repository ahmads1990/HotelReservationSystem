using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models.Enums;

namespace HotelReservationSystem.Common.views;

public record RequestResult<T>(T data, bool isSuccess, string message, ErrorCode errorCode)
{
    
    public static RequestResult<T> Success<T>(T data, string message = "")
    {
        return new RequestResult<T>(data, true, message, ErrorCode.None);
    }

    public static RequestResult<T> Failed<T>(ErrorCode errorCode)
    {
        return new RequestResult<T>(default, false, errorCode.GetDescription(), errorCode);
    }
}