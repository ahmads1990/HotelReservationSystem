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
        var reservation = new Reservation
        {
            GuestID = request.guestID,
            SpecialRequirements = request.specialRequirements,
            TotalAmount = request.Amount
        };

        await _repository.AddAsync(reservation);
        await _repository.SaveChangesAsync();

        return RequestResult<int>.Success(reservation.ID);

    }
}