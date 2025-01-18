using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        // [HttpPost]
        // [Authorize]
         
        // public async Task<ResponseViewModel<bool>> Add(AddRoomRequestViewModel requestViewModel)
        // {
        //     int id = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var parsedId) ? parsedId : -1;
        //     var newRoom = new AddRoomCommand(requestViewModel.RoomNumber, requestViewModel.Description, requestViewModel.IsAvailable, requestViewModel.RoomTypeID, id, requestViewModel.RoomFacilities);
        //     var response = await _mediator.Send(newRoom);
        //
        //     return response;
        // }

        // [HttpPut]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.UpdateRoom })]
        // public async Task<ResponseViewModel<bool>> Update(UpdateRoomViewModel viewModel)
        // {
        //     var command = viewModel.Map<UpdateRoomCommand>();
        //     var response = await _mediator.Send(command);
        //
        //     return response;
        // }
        //
        // [HttpPut]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.DeleteRoom })]
        // public async Task<ResponseViewModel<bool>> DeleteRoom(string roomNumber)
        // {
        //     var types = await _mediator.Send(new DeleteRoomCommand(roomNumber));
        //     return types;
        // }
        //
        // [HttpGet]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.GetAllRooms })]
        // public async Task<ResponseViewModel<IEnumerable<Room>>> GetAllRooms()
        // {
        //     var rooms = await _mediator.Send(new GetAllRoomsQuery());
        //     return rooms;
        // }
        //
        // [HttpGet]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.GetRoomByRoomNumber })]
        // public async Task<ResponseViewModel<Room>> GetRoomByRoomNumber(string roomNumber)
        // {
        //     var room = await _mediator.Send(new GetRoomByRoomNumberQuery(roomNumber));
        //     return room;
        // }
        //
        // [HttpGet]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.GetAvailableRooms })]
        // public async Task<ResponseViewModel<IEnumerable<Room>>> GetAvailableRooms()
        // {
        //     var rooms = await _mediator.Send(new GetAvailableRoomsQuery());
        //     return rooms;
        // }

    }
}
