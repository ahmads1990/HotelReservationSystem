using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries;

public record GetAllRoomsQuery() : IRequest<ResponseViewModel<IEnumerable<Room>>>;


public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, ResponseViewModel<IEnumerable<Room>>>
{
    private readonly IRepository<Room> _repository;

    public GetAllRoomsQueryHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<IEnumerable<Room>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _repository.GetAll().ToListAsync();

        if (rooms == null)
        {
            return new FailureResponseViewModel<IEnumerable<Room>>(ErrorCode.UserNotFound, "add room first");
        }

        return  new SuccessResponseViewModel<IEnumerable<Room>>(rooms);
    }
}
