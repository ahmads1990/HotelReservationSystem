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
using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands;

public record UpdateRoomWhenTypeChangedCommand(RoomTypeName typeName) : IRequest<ResponseViewModel<bool>>;

public class UpdateRoomWhenTypeChangedCommandHandler : IRequestHandler<UpdateRoomWhenTypeChangedCommand, ResponseViewModel<bool>>
{
    private readonly IRepository<Room> _repository;
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;
   
    public UpdateRoomWhenTypeChangedCommandHandler(IRepository<Room> repository,
        IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<ResponseViewModel<bool>> Handle(UpdateRoomWhenTypeChangedCommand request, CancellationToken cancellationToken)
    {
        var response = await ValidateRequest(request);

        if (!response.IsSuccess)
            return response;
        
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null)
        {
            return new ResponseViewModel<bool>
            {
                IsSuccess = false,
                Message = "Unauthorized"
            };
        }
        var userId = int.Parse(userIdClaim);
        
        var defaultRoomType = RoomTypeName.Single;
        
        
        var rowsAffected = await _repository.Query().Where(r => r.RoomTypeID == (int)request.typeName).ExecuteUpdateAsync(
                r => r
                    .SetProperty(r => r.RoomTypeID, _ => (int)defaultRoomType)
                    .SetProperty(r => r.UpdatedBy, _ => userId)
                    .SetProperty(r => r.UpdatedDate, _ => DateTime.UtcNow),
                cancellationToken);
  
        if (rowsAffected == 0)
        {
            return new ResponseViewModel<bool>
            {
                IsSuccess = false,
                Message = "No rooms were updated. Ensure the specified room type exists."
            };
        }

        return response;
    }

    private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomWhenTypeChangedCommand request)
    {
        
        if (request == default)
        {
            return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "room ID is required");
        }
        
        return new SuccessResponseViewModel<bool>(true);
    }
}