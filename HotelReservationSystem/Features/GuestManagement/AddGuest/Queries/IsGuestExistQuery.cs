using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.GuestManagement;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.GuestManagement.AddGuest.Queries;

public record IsGuestExistQuery(string NIDs) : IRequest<RequestResult<int>>;

public class IsGuestExistQueryHandler : IRequestHandler<IsGuestExistQuery, RequestResult<int>>
{
    readonly IRepository<Guest> _repository;
    public IsGuestExistQueryHandler(IRepository<Guest> repository)
    {
        _repository = repository;
    }

    public async Task<RequestResult<int>> Handle(IsGuestExistQuery request, CancellationToken cancellationToken)
    {
        if (request.NIDs == null || !request.NIDs.Any())
            return RequestResult<int>.Failed<int>(ErrorCode.InvalidInput);
        
        var existingGuestID = await _repository
            .Get(g => g.NID == request.NIDs).Select(g => g.ID).FirstOrDefaultAsync();

        if (existingGuestID == 0 )
        {
            return RequestResult<int>.Failed<int>(ErrorCode.None);
        }

        return RequestResult<List<int>>.Success(existingGuestID);
    }
}