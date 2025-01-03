using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;

public record UpdateRoomTypeCommand(int ID, RoomTypeName Name, double Price, string Description) : IRequest<ResponseViewModel<bool>>;

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, ResponseViewModel<bool>>
{
    private readonly IRepository<RoomType> _repository;
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateRoomTypeCommandHandler(IRepository<RoomType> repository,
        IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<ResponseViewModel<bool>> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await ValidateRequest(request);

        if (!response.IsSuccess)
            return response;

        var updatedRoomType = request.Map<RoomType>();
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        updatedRoomType.UpdatedBy = int.Parse(userIdClaim);

        _repository.SaveInclude(updatedRoomType,
                nameof(RoomType.RoomTypeName),
                         nameof(RoomType.Price),
                         nameof(RoomType.Description)
        );

        _repository.SaveChanges();

        return response;
    }

    private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomTypeCommand request)
    {
        if (request.Name==null)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
        }

        if (string.IsNullOrEmpty(request.Description))
        {
            return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Description is required");
        }

        if (request.Price <= 0)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
        }

       var roomtypeExists = await _mediator.Send(new IsRoomTypeExistsByIdNameQuery(request.ID, request.Name));

        if (roomtypeExists.Data)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
        }

        return new SuccessResponseViewModel<bool>(true);
    }
}