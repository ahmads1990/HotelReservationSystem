using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.Commands;

public record CreateReservationCommand(
    string RoomNumber,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    double Amount
) : IRequest<ResponseDTO<int>>;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ResponseDTO<int>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Reservation> _repository;

    public CreateReservationCommandHandler(IMediator mediator, IRepository<Reservation> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<ResponseDTO<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = request.Map<Reservation>();

        var reservationID = await _repository.AddAsync(reservation);
        _repository.SaveChanges();

        return new SuccessResponseDTO<int>(reservationID);

    }
}