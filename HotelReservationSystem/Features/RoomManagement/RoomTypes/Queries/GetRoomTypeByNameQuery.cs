// using HotelReservationSystem.Data.Repositories;
// using HotelReservationSystem.Models.Enums;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.Responses;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
//
// public record GetRoomTypeByNameQuery(int ID, string typeName) : IRequest<ResponseViewModel<RType>>;
//
//
// public class GetRoomTypeByNameQueryHandler : IRequestHandler<GetRoomTypeByNameQuery, ResponseViewModel<RType>>
// {
//     private readonly IRepository<RType> _repository;
//
//     public GetRoomTypeByNameQueryHandler(IRepository<RType> repository)
//     {
//         _repository = repository;
//     }
//
//     public async Task<ResponseViewModel<RType>> Handle(GetRoomTypeByNameQuery request, CancellationToken cancellationToken)
//     {
//         var roomType = await _repository.Get(rt => rt.Name == request.typeName).FirstOrDefaultAsync();
//
//         if (roomType == null)
//         {
//             return new FailureResponseViewModel<RType>(ErrorCode.UserNotFound, "room not exist");
//         }
//
//         return new SuccessResponseViewModel<RType>(roomType);
//     }
// }
