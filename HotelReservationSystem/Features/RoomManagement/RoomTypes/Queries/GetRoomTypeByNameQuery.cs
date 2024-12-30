using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;

public record GetRoomTypeByNameQuery(int ID, RoomTypeName typeName) : IRequest<ResponseViewModel<RoomType>>;


public class GetRoomTypeByNameQueryHandler : IRequestHandler<GetRoomTypeByNameQuery, ResponseViewModel<RoomType>>
{
    private readonly IRepository<RoomType> _repository;

    public GetRoomTypeByNameQueryHandler(IRepository<RoomType> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<RoomType>> Handle(GetRoomTypeByNameQuery request, CancellationToken cancellationToken)
    {
        var roomType = await _repository.Get(rt => rt.RoomTypeName == request.typeName).FirstOrDefaultAsync();

        if (roomType == null)
        {
            return new FailureResponseViewModel<RoomType>(ErrorCode.UserNotFound, "room not exist");
        }

        return new SuccessResponseViewModel<RoomType>(roomType);
    }
}
