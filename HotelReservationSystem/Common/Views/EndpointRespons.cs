using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models.Enums;

namespace HotelReservationSystem.Common;

public record EndpointRespons<T>(T data, bool isSuccess, string message, ErrorCode errorCode)
{
    public static EndpointRespons<T> Success<T>(T data, string message = "")
    {
        return new EndpointRespons<T>(data, true, message, ErrorCode.None);
    }

    public static EndpointRespons<T> Failed<T>(ErrorCode errorCode)
    {
        return new EndpointRespons<T>(default, false, errorCode.GetDescription(), errorCode);
    }
}