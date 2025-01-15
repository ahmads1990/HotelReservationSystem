using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries.DTOs;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.ReservationManagement.AddReservation.Queries;

public record GetAvailableRoomsQuery(int? roomTypeID = null, DateTime? fromDate = null, DateTime? toDate = null, double? fromAmount = null, double? toAmount = null) : IRequest<RequestResult<IEnumerable<AvailableRoomDTO>>>;

public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, RequestResult<IEnumerable<AvailableRoomDTO>>>
{
    IRepository<ReservationRoom> _repository;
    IMediator _mediator;

    public GetAvailableRoomsQueryHandler(IRepository<ReservationRoom> repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<RequestResult<IEnumerable<AvailableRoomDTO>>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _mediator.Send(new GetRoomByTypeOrPriceQuery(request.roomTypeID, request.fromAmount, request.toAmount));
        
        // Get All Rooms that have NO reservation in the date range
        return rooms.Map<RequestResult<IEnumerable<AvailableRoomDTO>>>();
    }
}