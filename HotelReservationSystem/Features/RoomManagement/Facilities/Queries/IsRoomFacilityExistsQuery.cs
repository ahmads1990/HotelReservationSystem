using HotelReservationSystem.Data.Repository;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Facilities.Queries
{
    public record IsRoomFacilityExistsQuery(string name) : IRequest<bool>;

    public class IsRoomFacilityExistsQueryHandler : IRequestHandler<IsRoomFacilityExistsQuery, bool>
    {
        readonly IRepository<Facility> _repository;
        public IsRoomFacilityExistsQueryHandler(IRepository<Facility> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomFacilityExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.Name == request.name);
        }
    }
}
