using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;

public record GetAllRoomTypesQuery() : IRequest<ResponseViewModel<IEnumerable<RoomType>>>;


public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, ResponseViewModel<IEnumerable<RoomType>>>
{
    private readonly IRepository<RoomType> _repository;

    public GetAllRoomTypesQueryHandler(IRepository<RoomType> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<IEnumerable<RoomType>>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
    {
        var roomType = await _repository.GetAll().ToListAsync();

        if (roomType == null)
        {
            return new FailureResponseViewModel<IEnumerable<RoomType>>(ErrorCode.UserNotFound, "add room first");
        }

        return new SuccessResponseViewModel<IEnumerable<RoomType>>(roomType);
    }
}
