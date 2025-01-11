using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Features.GuestManagement;
using HotelReservationSystem.Features.GuestManagement.Commands;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.Orchestrators;

public record CreateReservationOrchestrator(
    string RoomNumber,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    double Amount,
    List<GuestCreateDTO> Guests
) : IRequest<ResponseDTO<int>>;

public class CreateReservationOrchestratorHandler : IRequestHandler<CreateReservationOrchestrator,ResponseDTO<int>>
{
    private readonly IMediator _mediator;
    public CreateReservationOrchestratorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<ResponseDTO<int>> Handle(CreateReservationOrchestrator request, CancellationToken cancellationToken)
    {
        CreateReservationCommand reservationCMD = request.Map<CreateReservationCommand>();
        AddGuestsCommand addGuestsCmd = request.Map<AddGuestsCommand>();
        
        
        var reservation = await _mediator.Send(reservationCMD, cancellationToken);
        var reservationGuests = await _mediator.Send(addGuestsCmd, cancellationToken);

        // Return the successful response
        return new SuccessResponseDTO<int>(reservation.Data);

    }
}