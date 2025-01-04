using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes;

public record RoomTypeRemoved(int typeID) : INotification;
