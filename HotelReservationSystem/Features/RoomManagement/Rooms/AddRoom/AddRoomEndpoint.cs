using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.AddRoom })]
        
        public async Task<ResponseViewModel<bool>> AddRoom(AddRoomRequestViewModel requestViewModel)
        {
            int id = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var parsedId) ? parsedId : -1;
            var newRoom = new AddRoomCommand(requestViewModel.RoomNumber, requestViewModel.Description, requestViewModel.IsAvailable, requestViewModel.RoomTypeID, id, requestViewModel.RoomFacilities);
            var response = await _mediator.Send(newRoom);

            return response;
        }
    }
}
