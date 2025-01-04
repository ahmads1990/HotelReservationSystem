using HotelReservationSystem.Data.Repositories;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries
{
<<<<<<< HEAD
    public record IsRoomTypeExistsQuery(string roomTypeName) : IRequest<bool>;
=======
    public record IsRoomTypeExistsQuery(string typename) : IRequest<bool>;
>>>>>>> ff538dde934fb10473c2d11461008bdf586b7e8c

    public class IsRoomTypeExistsQueryHandler : IRequestHandler<IsRoomTypeExistsQuery, bool>
    {
        readonly IRepository<Models.RoomManagement.RoomType> _repository;
        public IsRoomTypeExistsQueryHandler(IRepository<Models.RoomManagement.RoomType> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomTypeExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.Name == request.roomTypeName);
        }
    }
}