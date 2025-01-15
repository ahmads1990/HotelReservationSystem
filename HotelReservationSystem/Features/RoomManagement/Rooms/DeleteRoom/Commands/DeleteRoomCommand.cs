// using HotelReservationSystem.AutoMapper;
// using HotelReservationSystem.Data.Repositories;
// using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
// using HotelReservationSystem.Models.Enums;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.Responses;
// using MediatR;
// using System.Security.Claims;
//
// namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
//
// public record DeleteRoomCommand(string roomNumber) : IRequest<ResponseViewModel<bool>>;
//
// public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ResponseViewModel<bool>>
// {
//     private readonly IRepository<Room> _repository;
//     private readonly IMediator _mediator;
//     private readonly IHttpContextAccessor _httpContextAccessor;
//
//     public DeleteRoomCommandHandler(IRepository<Room> repository,
//         IMediator mediator, IHttpContextAccessor httpContextAccessor)
//     {
//         _repository = repository;
//         _mediator = mediator;
//         _httpContextAccessor = httpContextAccessor;
//
//     }
//     public async Task<ResponseViewModel<bool>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
//     {
//         var response = await ValidateRequest(request);
//
//         if (!response.IsSuccess)
//             return response;
//
//         var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//         if (userIdClaim == null)
//         {
//             return new ResponseViewModel<bool>
//             {
//                 IsSuccess = false,
//                 Message = "Unauthorized"
//             };
//         }
//         var userId = int.Parse(userIdClaim);
//
//         var deletedRoom = request.Map<Room>();
//         deletedRoom.UpdatedBy = userId;
//         deletedRoom.Deleted = true;
//         _repository.SaveInclude(deletedRoom,
//                 nameof(Room.Deleted),
//                 nameof(Room.UpdatedBy)
//         );
//         _repository.SaveChanges();
//
//         return response;
//     }
//
//     private async Task<ResponseViewModel<bool>> ValidateRequest(DeleteRoomCommand request)
//     {
//
//         if (request.roomNumber == default)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "room ID is required");
//         }
//         var roomExists = await _mediator.Send(new IsRoomExistsQuery(request.roomNumber));
//
//         if (!roomExists)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput);
//         }
//
//
//
//
//         return new SuccessResponseViewModel<bool>(true);
//     }
// }