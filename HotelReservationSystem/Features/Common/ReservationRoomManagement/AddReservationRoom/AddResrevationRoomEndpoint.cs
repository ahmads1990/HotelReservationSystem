using HotelReservationSystem.Common.views;
using HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom;

[ApiController]
[Route("[controller]/[action]")]
public class AddResrevationRoomEndpoint : ControllerBase
{
    readonly IMediator _mediator;

    public AddResrevationRoomEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<EndpointRespons<int>> AddReservationRoom()
    {
        var rr = new AddReservationRoomCommand(2,8, DateTime.Now, DateTime.Now.AddDays(1));
        var response = await _mediator.Send(rr);
        return EndpointRespons<int>.Success(response.data);
    }
} 