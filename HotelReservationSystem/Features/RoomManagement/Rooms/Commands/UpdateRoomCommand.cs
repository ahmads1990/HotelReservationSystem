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
// public record UpdateRoomCommand(int ID, string roomNumber, string description, bool isAvailable, int roomTypeID, int[] customFacilities) : IRequest<ResponseViewModel<bool>>;
//
// public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, ResponseViewModel<bool>>
// {
//     private readonly IRepository<Room> _repository;
//     private readonly IMediator _mediator;
//     private readonly IHttpContextAccessor _httpContextAccessor;
//
//     public UpdateRoomCommandHandler(IRepository<Room> repository,
//         IMediator mediator, IHttpContextAccessor httpContextAccessor)
//     {
//         _repository = repository;
//         _mediator = mediator;
//         _httpContextAccessor = httpContextAccessor;
//
//     }
//     public async Task<ResponseViewModel<bool>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
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
//         var updatedRoom = request.Map<Room>();
//         updatedRoom.UpdatedBy = userId;
//         _repository.SaveInclude(updatedRoom,
//                 nameof(Room.RoomNumber),
//                 nameof(Room.Description),
//                 nameof(Room.IsAvailable),
//                 nameof(Room.RTypeID),
//                 nameof(Room.UpdatedBy),
//                 nameof(Room.RoomFacilities)
//         );
//
//         _repository.SaveChanges();
//
//         return response;
//     }
//
//     private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomCommand request)
//     {
//
//         if (request.ID == default)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "room ID is required");
//         }
//         if (string.IsNullOrEmpty(request.roomNumber))
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "room number is required");
//         }
//
//         if (string.IsNullOrEmpty(request.description))
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Description is required");
//         }
//
//
//         var roomExists = await _mediator.Send(new IsRoomExistsQuery(request.roomNumber));
//
//         if (roomExists)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
//         }
//
//         return new SuccessResponseViewModel<bool>(true);
//     }
// }