// using HotelReservationSystem.Data.Repositories;
// using HotelReservationSystem.Models.Enums;
// using HotelReservationSystem.Models.RoomManagement;
// using HotelReservationSystem.ViewModels.Responses;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
//
// public record GetRoomByRoomNumberQuery(string roomNumber) : IRequest<ResponseViewModel<Room>>;
//
//
// public class GetRoomByRoomNumberQueryHandler : IRequestHandler<GetRoomByRoomNumberQuery, ResponseViewModel<Room>>
// {
//     private readonly IRepository<Room> _repository;
//
//     public GetRoomByRoomNumberQueryHandler(IRepository<Room> repository)
//     {
//         _repository = repository;
//     }
//
//     public async Task<ResponseViewModel<Room>> Handle(GetRoomByRoomNumberQuery request, CancellationToken cancellationToken)
//     {
//         var room = await _repository.Get(room => room.RoomNumber == request.roomNumber).FirstOrDefaultAsync();
//
//         if (room == null)
//         {
//             return new FailureResponseViewModel<Room>(ErrorCode.RoomNotFound, "add room first");
//         }
//
//         return new SuccessResponseViewModel<Room>(room);
//     }
//
// }
