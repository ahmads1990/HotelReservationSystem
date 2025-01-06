using HotelReservationSystem.Models.Enums;

namespace HotelReservationSystem.DTOs;

public class ResponseDTO<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; } = true;
    public ErrorCode ErrorCode { get; set; }
    public string Message { get; set; }
}

public class SuccessResponseDTO<T> : ResponseDTO<T>
{
    public SuccessResponseDTO(T data, string message = "")
    {
        Data = data;
        IsSuccess = true;
        Message = message;
        ErrorCode = ErrorCode.None;
    }
}

public class FailureResponseDTO<T> : ResponseDTO<T>
{
    public FailureResponseDTO(ErrorCode errorCode, string message = "")
    {
        Data = default;
        IsSuccess = false;
        Message = message;
        ErrorCode = errorCode;
    }
}
