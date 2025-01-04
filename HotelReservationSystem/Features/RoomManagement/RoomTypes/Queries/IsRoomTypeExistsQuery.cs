using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries
{
    public record IsRoomTypeExistsQuery(string typename) : IRequest<bool>;

    public class IsRoomTypeExistsQueryHandler : IRequestHandler<IsRoomTypeExistsQuery, bool>
    {
        readonly IRepository<Models.RoomManagement.RoomType> _repository;
        public IsRoomTypeExistsQueryHandler(IRepository<Models.RoomManagement.RoomType> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomTypeExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.RoomTypeName == request.typename);
        }
    }
}