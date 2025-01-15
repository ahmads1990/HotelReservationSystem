// using HotelReservationSystem.AutoMapper;
// using HotelReservationSystem.Data.Repositories;
// using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
// using HotelReservationSystem.Models.Enums;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.Responses;
// using MediatR;
// using System.Security.Claims;
//
// namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
//
// public record UpdateRoomTypeCommand(int ID, string Name, double Price, string Description) : IRequest<ResponseViewModel<bool>>;
//
// public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, ResponseViewModel<bool>>
// {
//     private readonly IRepository<RType> _repository;
//     private readonly IMediator _mediator;
//     private readonly IHttpContextAccessor _httpContextAccessor;
//
//     public UpdateRoomTypeCommandHandler(IRepository<RType> repository,
//         IMediator mediator, IHttpContextAccessor httpContextAccessor)
//     {
//         _repository = repository;
//         _mediator = mediator;
//         _httpContextAccessor = httpContextAccessor;
//
//     }
//     public async Task<ResponseViewModel<bool>> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
//     {
//         var response = await ValidateRequest(request);
//
//         if (!response.IsSuccess)
//             return response;
//
//         var updatedRoomType = request.Map<RType>();
//         var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//         updatedRoomType.UpdatedBy = int.Parse(userIdClaim);
//
//         _repository.SaveInclude(updatedRoomType,
//                 nameof(RType.Name),
//                          nameof(RType.Price),
//                          nameof(RType.Description)
//         );
//
//         _repository.SaveChanges();
//
//         return response;
//     }
//
//     private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomTypeCommand request)
//     {
//         if (request.Name == null)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
//         }
//
//         if (string.IsNullOrEmpty(request.Description))
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Description is required");
//         }
//
//         if (request.Price <= 0)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
//         }
//
//         var validationResult = await _mediator.Send(new ValidateRoomTypeUpdateQuery(request.ID, request.Name));
//
//         if (!validationResult.Data.ExistsById) 
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
//         }
//
//         if (!validationResult.Data.NameIsUnique)
//         {
//             return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
//         }
//
//         return new SuccessResponseViewModel<bool>(true);
//     }
// }