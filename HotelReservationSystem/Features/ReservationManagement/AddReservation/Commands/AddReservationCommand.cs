using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;

public record AddReservationCommand(
    int guestID,
    string specialRequirements,
    double Amount 
) : IRequest<RequestResult<int>>;

public class CreateReservationCommandHandler : IRequestHandler<AddReservationCommand, RequestResult<int>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Reservation> _repository;

    public CreateReservationCommandHandler(IMediator mediator, IRepository<Reservation> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<RequestResult<int>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = request.Map<Reservation>();

        var reservationID = await _repository.AddAsync(reservation);
        _repository.SaveChanges();

        return RequestResult<int>.Success(reservationID);

    }
}