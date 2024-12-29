using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries
{
    public record IsRoomTypeExistsQuery(string name) : IRequest<bool>;

    public class IsRoomTypeExistsQueryHandler : IRequestHandler<IsRoomTypeExistsQuery, bool>
    {
        readonly IRepository<Models.RoomManagement.RType> _repository;
        public IsRoomTypeExistsQueryHandler(IRepository<Models.RoomManagement.RType> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomTypeExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.Name == request.name);
        }
    }
}
