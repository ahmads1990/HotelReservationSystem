﻿using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Facilities.Queries
{
    public record IsRoomExistsQuery(string name) : IRequest<bool>;

    public class IsRoomFacilityExistsQueryHandler : IRequestHandler<IsRoomExistsQuery, bool>
    {
        readonly IRepository<RoomFacility> _repository;
        public IsRoomFacilityExistsQueryHandler(IRepository<RoomFacility> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsRoomExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(x => x.Name == request.name);
        }
    }
}
