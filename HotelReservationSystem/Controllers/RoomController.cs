using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.Rooms.Queries;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using HotelReservationSystem.ViewModels.RoomManagment.Rooms;
using MediatR;
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

        [HttpPost()]
        public async Task<ResponseViewModel<bool>> Add(CreateRoomViewModel viewModel)
        {
            var response = await _mediator.Send(new AddRoomCommand(viewModel., viewModel.Price));

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
        public async Task<ResponseViewModel<IEnumerable<Room>>> GetAllRooms()
        {
            var types = await _mediator.Send(new GetAllRoomsQuery());
            return types;
        }
    }
}
 