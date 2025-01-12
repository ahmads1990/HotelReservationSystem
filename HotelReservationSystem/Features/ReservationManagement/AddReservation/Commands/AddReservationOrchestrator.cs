using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.Features.GuestManagement;
using HotelReservationSystem.Features.GuestManagement.Commands;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.Models.ReservationManagement;
using HotelReservationSystem.RabbitMQ;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;

public record AddReservationOrchestrator(
    string RoomNumber,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    double Amount,
    List<GuestCreateDTO> Guests
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
        
        AddReservationCommand reservationCMD = request.Map<AddReservationCommand>();
        AddListOfGuestsCommand addListOfGuestsCmd = request.Map<AddListOfGuestsCommand>();
        
        
        var reservation = await _mediator.Send(reservationCMD, cancellationToken);
        var reservationGuests = await _mediator.Send(addListOfGuestsCmd, cancellationToken);

        // Return the successful response
        return reservation;

    }
}