using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.RoomManagement.Rooms.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;
using HotelReservationSystem.ViewModels.RoomManagment.RTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
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

        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdateRoomTypeViewModel viewModel)
        {
            var command = viewModel.Map<UpdateRoomTypeCommand>();
            var response = await _mediator.Send(command);

            return response;
        }

        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<RoomType>>> GetAllRoomTypes()
        {
            var types = await _mediator.Send(new GetAllRoomTypesQuery());
            return types;
        }
        
        [HttpPut]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.DeleteRoomType })]
        public async Task<ResponseViewModel<bool>> DeleteRoomType(RoomTypeName roomNumber)
        {
            var types = await _mediator.Send(new DeleteRoomTypeCommand(roomNumber));
            return types;
        }
    }
}
 