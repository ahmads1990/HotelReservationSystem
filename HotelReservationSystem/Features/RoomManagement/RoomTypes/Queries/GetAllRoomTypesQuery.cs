// using HotelReservationSystem.Data.Repositories;
// using HotelReservationSystem.Models.Enums;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.Responses;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
//
// public record GetAllRoomTypesQuery() : IRequest<ResponseViewModel<IEnumerable<RType>>>;
//
//
// public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, ResponseViewModel<IEnumerable<RType>>>
// {
//     private readonly IRepository<RType> _repository;
//
//     public GetAllRoomTypesQueryHandler(IRepository<RType> repository)
//     {
//         _repository = repository;
//     }
//
//     public async Task<ResponseViewModel<IEnumerable<RType>>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
//     {
//         var roomType = await _repository.GetAll().ToListAsync();
//
//         if (!roomType.Any())
//         {
//             return new FailureResponseViewModel<IEnumerable<RType>>(ErrorCode.UserNotFound, "add room first");
//         }
//
//         return new SuccessResponseViewModel<IEnumerable<RType>>(roomType);
//     }
// }
