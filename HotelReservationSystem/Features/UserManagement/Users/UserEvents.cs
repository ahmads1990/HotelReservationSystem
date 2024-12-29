using MediatR;

namespace HotelReservationSystem.CQRS.users;

public record UserRemoved(int ID) : INotification;
public record UserAdedd(int ID) : INotification;