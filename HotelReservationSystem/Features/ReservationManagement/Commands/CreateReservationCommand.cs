using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.Commands;

public record CreateReservationCommand(
    string RoomNumber,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    double Amount,
    List<GuestCreateDTO> Guests
) : IRequest<ReservationDTO>;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationDTO>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Reservation> _repository;

    public CreateReservationCommandHandler(IMediator mediator, IRepository<Reservation> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<ReservationDTO> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = request.Map<Reservation>(request);

        await _reservationRepository.AddAsync(reservation);

        var reservationDto = _mapper.Map<ReservationDTO>(reservation);

        return reservationDto;
    }
}