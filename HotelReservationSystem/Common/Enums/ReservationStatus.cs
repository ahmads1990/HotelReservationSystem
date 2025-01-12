using HotelReservationSystem.Helpers;

namespace HotelReservationSystem.Models.ReservationManagement;

public enum ReservationStatus
{
    [Description("Pending confirmation", "انتظار التأكيد")]
    Pending = 10,
    [Description("Confirmed", "مؤكد")]
    Confirmed = 20,
    [Description("Cancelled", "ملغى")]
    Cancelled = 30,
    [Description("Partial-Payment", "مدفوع جزئيا")]
    PartialPayment = 40,
}