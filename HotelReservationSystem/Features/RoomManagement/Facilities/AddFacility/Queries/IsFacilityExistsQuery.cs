using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Facilities.Queries
{
    public record IsRoomExistsQuery(string name) : IRequest<bool>;

    public class IsRoomFacilityExistsQueryHandler : IRequestHandler<IsRoomExistsQuery, bool>
    {
        readonly IRepository<Facility> _repository;
        public IsRoomFacilityExistsQueryHandler(IRepository<Facility> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.Name == request.name);
        }
    }
}
