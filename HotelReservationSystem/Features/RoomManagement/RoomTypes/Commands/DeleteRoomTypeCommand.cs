using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using System.Security.Claims;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;

public record DeleteRoomTypeCommand(string typeName) : IRequest<ResponseViewModel<bool>>;

public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, ResponseViewModel<bool>>
{
    private readonly IRepository<RoomType> _repository;
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DeleteRoomTypeCommandHandler(IRepository<RoomType> repository,
        IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<ResponseViewModel<bool>> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await ValidateRequest(request);

        if (!response.IsSuccess)
            return response;

        var deletedRoomType = request.Map<RoomType>();
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        deletedRoomType.UpdatedBy = int.Parse(userIdClaim);
        deletedRoomType.Deleted = true;

        _repository.SaveInclude(deletedRoomType,
                nameof(RoomType.Deleted),
                nameof(RoomType.UpdatedBy)
        );

        _repository.SaveChanges();

        await _mediator.Publish(new RoomTypeRemoved(deletedRoomType.ID));
        return response;
    }

    private async Task<ResponseViewModel<bool>> ValidateRequest(DeleteRoomTypeCommand request)
    {
        if (request.typeName == null)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
        }

        var roomtypeExists = await _mediator.Send(new IsRoomTypeExistsQuery(request.typeName));

        if (!roomtypeExists)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput);
        }

        return new SuccessResponseViewModel<bool>(true);
    }
}