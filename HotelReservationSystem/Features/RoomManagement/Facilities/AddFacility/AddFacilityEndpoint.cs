using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Features.RoomManagement.Facilities.AddFacility.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Features.RoomManagement.Facilities.AddFacility;

[ApiController]
[Route("[controller]/[action]")]
public class AddFacilityEndpoint : ControllerBase   
{
    readonly IMediator _mediator;

    public AddFacilityEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<EndpointRespons<bool>> AddRoom(AddFacilityRequestViewModel requestViewModel)
    {
        var newFacilityCommand = new AddFacilityCommand(requestViewModel.Name, requestViewModel.Price, requestViewModel.Description);

        var response = await _mediator.Send(newFacilityCommand);
        return response.Map<EndpointRespons<bool>>();
    }
}


