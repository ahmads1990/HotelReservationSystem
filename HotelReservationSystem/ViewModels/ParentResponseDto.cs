using HotelSystem.Models.Enums;

namespace HotelReservationSystem.ViewModels
{
    public class ParentResponseDto
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }

        public string Message { get; set; }

        public ErrorCode StatusEnum { get; set; }
    }
}
