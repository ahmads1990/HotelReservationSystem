using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;

public record ValidateRoomTypeUpdateQuery(int ID, string typeName) : IRequest<ResponseViewModel<ValidateRoomTypeUpdate>>;

public class ValidateRoomTypeUpdate
{
    public bool ExistsById { get; set; }
    public bool NameIsUnique { get; set; }
}


public class CheckRoomTypeExistsByNameQueryHandler : IRequestHandler<ValidateRoomTypeUpdateQuery, ResponseViewModel<ValidateRoomTypeUpdate>>
{
    private readonly IRepository<RoomType> _repository;

    public CheckRoomTypeExistsByNameQueryHandler(IRepository<RoomType> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseViewModel<ValidateRoomTypeUpdate>> Handle(ValidateRoomTypeUpdateQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _repository.GetAll()
                 .GroupBy(r => 1)
                 .Select(g => new ValidateRoomTypeUpdate
                 {
                     ExistsById = g.Any(r => r.ID == request.ID), // True if ID exists
                     NameIsUnique = !g.Any(r => r.ID != request.ID && r.Name == request.typeName) // True if name is unique
                 })
                 .FirstOrDefaultAsync();

        return new SuccessResponseViewModel<ValidateRoomTypeUpdate>(validationResult);
    }
}
