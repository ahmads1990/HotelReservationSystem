using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.EventsHandler;

public class RoomTypeRemovedHandler: INotificationHandler<RoomTypeRemoved>
{
    IMediator _mediator;
    public RoomTypeRemovedHandler(IMediator mediator) 
    {
        _mediator = mediator;
    }
    public Task Handle(RoomTypeRemoved notification, CancellationToken cancellationToken)
    {
        return _mediator.Send(new UpdateRoomWhenTypeChangedCommand(notification.typeID));
    }
}  