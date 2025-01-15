using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.Common.views;

namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AddRoomEndpoint : ControllerBase
    {
        readonly IMediator _mediator;

        public AddRoomEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.AddRoom })]
        
        public async Task<EndpointRespons<bool>> AddRoom(AddRoomRequestViewModel requestViewModel)
        {
            
            var newRoom = new AddRoomCommand(requestViewModel.RoomNumber, requestViewModel.Description, requestViewModel.IsAvailable, requestViewModel.RoomTypeID,1, requestViewModel.RoomFacilities);
            var response = await _mediator.Send(newRoom);

            return response.data.Map<EndpointRespons<bool>>();
        }
    }
}
