using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries;

public record GetAvailableRoomsQuery() : IRequest<ResponseViewModel<IEnumerable<Room>>>;


public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, ResponseViewModel<IEnumerable<Room>>>
{
    private readonly IRepository<Room> _repository;

    public GetAvailableRoomsQueryHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<IEnumerable<Room>>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _repository.Get(room => room.IsAvailable == true).ToListAsync();

        if (rooms == null)
        {
            return new FailureResponseViewModel<IEnumerable<Room>>(ErrorCode.UserNotFound, "add room first");
        }

        return new SuccessResponseViewModel<IEnumerable<Room>>(rooms);
    }
}

