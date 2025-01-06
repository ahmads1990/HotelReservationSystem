using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.Queries;

public record GetAvailableRoomsQuery(int? roomTypeID = null, DateTime? fromDate = null, DateTime? toDate = null, double? fromAmount = null, double? toAmount = null) : IRequest<IEnumerable<AvailableRoomDTO>>;

public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, IEnumerable<AvailableRoomDTO>>
{
    IRepository<ReservationRoom> _repository;
    IMediator _mediator;

    public GetAvailableRoomsQueryHandler(IRepository<ReservationRoom> repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<AvailableRoomDTO>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _mediator.Send(new GetRoomByTypeOrPriceQuery(request.roomTypeID, request.fromAmount, request.toAmount));
        return rooms.Map<IEnumerable<AvailableRoomDTO>>();
        // Get All Rooms that have NO reservation in the date range
    }
}