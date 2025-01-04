using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;

public record IsRoomTypeExistsByIdNameQuery(int ID, string typeName) : IRequest<ResponseViewModel<bool>>;


public class IsRoomTypeExistsByIdNameQueryHandler : IRequestHandler<IsRoomTypeExistsByIdNameQuery, ResponseViewModel<bool>>
{
    private readonly IRepository<RoomType> _repository;

    public IsRoomTypeExistsByIdNameQueryHandler(IRepository<RoomType> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<bool>> Handle(IsRoomTypeExistsByIdNameQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.AnyAsync(rt => rt.ID == request.ID || rt.RoomTypeName == request.typeName);

        return new SuccessResponseViewModel<bool>(result);
    }
}
