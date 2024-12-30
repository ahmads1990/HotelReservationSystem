using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Queries
{
    public record IsRoomExistsQuery(string roomNumber) : IRequest<bool>;

    public class IsRoomExistsQueryHandler : IRequestHandler<IsRoomExistsQuery, bool>
    {
        readonly IRepository<Room> _repository;
        public IsRoomExistsQueryHandler(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.RoomNumber == request.roomNumber);
        }
    }
}
