using HotelReservationSystem.Common;
using HotelReservationSystem.Data;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries;

public record IsReservationValidQuery() : IRequest<RequestResult<bool>>;

public class IsReservationValidQueryHandler : IRequestHandler<IsReservationValidQuery, RequestResult<bool>>
{
    private readonly IRepository<Reservation> _repository;

    public IsReservationValidQueryHandler(IRepository<Reservation> repository)
    {
        _repository = repository;
    }

    public async Task<RequestResult<bool>> Handle(IsReservationValidQuery request, CancellationToken cancellationToken)
    {
        return  RequestResult<bool>.Success(true);
    }
}