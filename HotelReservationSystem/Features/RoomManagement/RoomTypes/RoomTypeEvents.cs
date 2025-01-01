using HotelReservationSystem.Data.Enums;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes;

public record RoomTypeRemoved(RoomTypeName typeName) : INotification;
