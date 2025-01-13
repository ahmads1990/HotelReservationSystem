using System.Data.Entity;
using HotelReservationSystem.Common;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.GuestManagement;
using MediatR;

namespace HotelReservationSystem.Features.GuestManagement.AddListOfGuests.Queries;

public record IsGuestExistQuery(List<string> NIDs) : IRequest<RequestResult<List<string>>>;

public class IsGuestExistQueryHandler : IRequestHandler<IsGuestExistQuery, RequestResult<List<string>>>
{
    readonly IRepository<Guest> _repository;
    public IsGuestExistQueryHandler(IRepository<Guest> repository)
    {
        _repository = repository;
    }

    public async Task<RequestResult<List<string>>> Handle(IsGuestExistQuery request, CancellationToken cancellationToken)
    {
        if (request.NIDs == null || !request.NIDs.Any())
            return RequestResult<List<string>>.Failed<List<string>>(ErrorCode.InvalidInput);

        // Use GetAll() and apply filtering with LINQ
        var existingGuests = await _repository
            .GetAll()
            .Where(g => request.NIDs.Contains(g.NID)).Select(g => g.NID).ToListAsync();
        

        return RequestResult<List<string>>.Success(existingGuests);
    }
}