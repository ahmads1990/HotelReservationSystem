using System.Linq.Expressions;
using HotelReservationSystem.Common;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions;


namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries;

public record GetRoomByTypeOrPriceQuery (int? roomTypeID = null, double? fromAmount = null, double? toAmount = null) : IRequest<RequestResult<IEnumerable<AvailableRoomTypesInPriceRangeDTO>>>;

public class GetRoomByTypeOrPriceQueryHandler : IRequestHandler<GetRoomByTypeOrPriceQuery, RequestResult<IEnumerable<AvailableRoomTypesInPriceRangeDTO>>>
{
    IRepository<Room> _repository;
    public GetRoomByTypeOrPriceQueryHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<RequestResult<IEnumerable<AvailableRoomTypesInPriceRangeDTO>>> Handle(GetRoomByTypeOrPriceQuery request, CancellationToken cancellationToken)
    {
        var predicate = BuildPredicate(request);

        var rooms = await _repository.Get(predicate)
            .Select(x => new AvailableRoomTypesInPriceRangeDTO
            { 
                ID = x.ID,
                RoomTypeID = x.RoomTypeID,
                RoomTypeName = x.RoomType.Name,
                BasicPrice = x.RoomType.Price,
            }).ToListAsync();

        return  RequestResult<IEnumerable<AvailableRoomTypesInPriceRangeDTO>>.Success((IEnumerable<AvailableRoomTypesInPriceRangeDTO>)rooms);
    }

    private Expression<Func<Room, bool>> BuildPredicate(GetRoomByTypeOrPriceQuery request)
    {
        var predicate = PredicateExtensions.PredicateExtensions.Begin<Room>(false); 

        predicate.And(x => !request.roomTypeID.HasValue || x.RoomTypeID == request.roomTypeID.Value);

        predicate.And(x => !request.fromAmount.HasValue || x.RoomType.Price >= request.fromAmount.Value);

        predicate.And(x => !request.toAmount.HasValue || x.RoomType.Price <= request.toAmount.Value);

        return predicate;
    }
}