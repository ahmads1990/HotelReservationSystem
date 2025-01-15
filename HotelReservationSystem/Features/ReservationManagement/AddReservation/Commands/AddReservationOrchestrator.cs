using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;
using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom.Commands;
using HotelReservationSystem.Features.GuestManagement.AddGuest.Commands;
using HotelReservationSystem.Features.GuestManagement.AddGuest;
using HotelReservationSystem.Features.GuestManagement.AddGuest.Commands;
using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.RabbitMQ;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;

public record AddReservationOrchestrator(
    string mainGuestNID,
    double amount,
    List<ReservationRoomCreateRequestViewModel> reservationRooms
) : IRequest<RequestResult<int>>;

public class AddReservationOrchestratorHandler : IRequestHandler<AddReservationOrchestrator,RequestResult<int>>
{
    private readonly IMediator _mediator;
    private readonly RabbitMQPuublisherService _rabbitMqPuublisherService;
    public AddReservationOrchestratorHandler(IMediator mediator, RabbitMQPuublisherService rabbitMqPuublisherService)
    {
        _mediator = mediator;
        _rabbitMqPuublisherService = rabbitMqPuublisherService;
    }
    public async Task<RequestResult<int>> Handle(AddReservationOrchestrator request, CancellationToken cancellationToken)
    {
        var addGuestCommand = request.reservationRooms.SelectMany(g => g.Guests)
            .Where(g => g.NID == request.mainGuestNID)
            .Select(g => new AddGuestCommand(name: g.Name, NID: g.NID, phoneNumber: g.PhoneNumber, age: g.Age)).FirstOrDefault();
        var mainGuestID = await _mediator.Send(addGuestCommand);
        
        var reservationCommand = new AddReservationCommand(guestID: mainGuestID.data, specialRequirements: "jfdhsfds", request.amount );
        var reser_ID = await _mediator.Send(reservationCommand);

        foreach (var reservationRoom in request.reservationRooms)
        {
            // For each reservation room, add the reservation room details
            var reservationRoomCommand = new AddReservationRoomCommand(reservationRoom.RoomID,reser_ID.data, reservationRoom.CheckInDate, reservationRoom.CheckOutDate);
            var reservationRoomIDs = await _mediator.Send(reservationRoomCommand);

            // Process the guests for the current room
            var roomGuests = reservationRoom.Guests.Select(g => new AddGuestCommand(name: g.Name, NID: g.NID, phoneNumber: g.PhoneNumber, age: g.Age))
                .ToList();

            foreach (var roomGuest in roomGuests)
            {
                var guestID = await _mediator.Send(roomGuest);
                await _mediator.Send(new AssignGuestToReservationRoomCommand(guestID.data, reservationRoomIDs.data));
            }
        }
        return RequestResult<int>.Success(reser_ID.data);
    }
}