using System.Reflection.Emit;
using System.Security.Claims;
using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomController : ControllerBase
    {
        readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.AddRoom })]

        public async Task<ResponseViewModel<bool>> Add(CreateRoomViewModel viewModel)
        {
            int id = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var parsedId) ? parsedId : -1;
            // var http = HttpContext;
            // var user = http.User;
            // var userId = user.FindFirst("ID")?.Value;
            // int id = int.Parse(userId);
            var newRoom = new AddRoomCommand(viewModel.RoomNumber, viewModel.Description, viewModel.IsAvailable, viewModel.RoomTypeID, id);

            
            var response = await _mediator.Send(newRoom);

            return response;
        }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdateRoomViewModel viewModel)
        {
            var command = viewModel.Map<UpdateRoomCommand>();
            var response = await _mediator.Send(command);

            return response;
        }

        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.GetAllRooms })]
        public async Task<ResponseViewModel<IEnumerable<Room>>> GetAllRooms()
        {
            var types = await _mediator.Send(new GetAllRoomsQuery());
            return types;
        }
    }
}
 