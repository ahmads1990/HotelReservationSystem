
using System.Linq.Expressions;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs.RoomManagement.Rooms;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions;


namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries;

public record GetRoomByTypeOrPriceQuery (int? roomTypeID = null, double? fromAmount = null, double? toAmount = null) : IRequest<IEnumerable<RoomDTO>>;

public class GetRoomByTypeOrPriceQueryHandler : IRequestHandler<GetRoomByTypeOrPriceQuery, IEnumerable<RoomDTO>>
{
    IRepository<Room> _repository;
    public GetRoomByTypeOrPriceQueryHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RoomDTO>> Handle(GetRoomByTypeOrPriceQuery request, CancellationToken cancellationToken)
    {
        var predicate = BuildPredicate(request);

        var rooms = await _repository.Get(predicate)
            .Select(x => new RoomDTO
            { 
                ID = x.ID,
                RoomTypeID = x.RoomTypeID,
                RoomTypeName = x.RoomType.Name,
                BasicPrice = x.RoomType.Price,
            }).ToListAsync();

        return rooms;
    }

    private Expression<Func<Room, bool>> BuildPredicate(GetRoomByTypeOrPriceQuery request)
    {
        var predicate = PredicateExtensions.Predicate.Begin<Room>(true);

        predicate.And(x => !request.roomTypeID.HasValue || x.RoomTypeID == request.roomTypeID.Value);

        predicate.And(x => !request.fromAmount.HasValue || x.RoomType.Price >= request.fromAmount.Value);

        predicate.And(x => !request.toAmount.HasValue || x.RoomType.Price >= request.toAmount.Value);

        return predicate;
    }
}