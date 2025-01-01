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

//     public Task Handle(RoomTypeRemoved notification, CancellationToken cancellationToken)
//     {
//         // await _mediator.Send(new RemoveExamsByInstructorIDCommand(request.id));
//     }
    public Task Handle(RoomTypeRemoved notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}