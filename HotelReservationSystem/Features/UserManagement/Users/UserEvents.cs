using MediatR;

namespace FOOD_APP_JSB_2.CQRS.users;

public record UserRemoved(int ID) : INotification;
public record UserAdedd(int ID) : INotification;