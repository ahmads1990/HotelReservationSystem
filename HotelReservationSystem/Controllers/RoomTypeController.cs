using HotelSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelSystem.ViewModels;
using HotelSystem.ViewModels.RoomManagment.RoomTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomTypeController : ControllerBase
    {
        readonly IMediator _mediator;
        public RoomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<ResponseViewModel<bool>> Add(CreateRoomTypeViewModel viewModel)
        {
            var response = await _mediator.Send(new AddRoomTypeCommand(viewModel.Name, viewModel.Price));

            return response;
        }
    }
}
