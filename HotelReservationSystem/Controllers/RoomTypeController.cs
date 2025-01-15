using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.RabbitMQ;
using HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;
using HotelReservationSystem.ViewModels.RoomManagment.RTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomTypeController : ControllerBase
    {
        readonly IMediator _mediator;
        RabbitMQPuublisherService _rabbitMqPuublisherService;
        public RoomTypeController(IMediator mediator, RabbitMQPuublisherService rabbitMqPuublisherService)
        {
            _mediator = mediator;
            _rabbitMqPuublisherService = rabbitMqPuublisherService;
        }

        // [HttpPost()]
        // public async Task<ResponseViewModel<bool>> Add(CreateRoomTypeViewModel viewModel)
        // {
        //     var command = viewModel.Map<AddRoomTypeCommand>();
        //     var response = await _mediator.Send(command);
        //
        //     return response;
        // }
        //
        // [HttpPut]
        // public async Task<ResponseViewModel<bool>> Update(UpdateRoomTypeViewModel viewModel)
        // {
        //     var command = viewModel.Map<UpdateRoomTypeCommand>();
        //     var response = await _mediator.Send(command);
        //
        //     return response;
        // }
        //
        // [HttpGet]
        // public async Task<ResponseViewModel<IEnumerable<RType>>> GetAllRoomTypes()
        // {
        //     var types = await _mediator.Send(new GetAllRoomTypesQuery());
        //     await _rabbitMqPuublisherService.Publish("message");
        //     return types;
        // }
        //
        //
        // [HttpPut]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.DeleteRoomType })]
        // public async Task<ResponseViewModel<bool>> DeleteRoomType(string roomNumber)
        // {
        //     var types = await _mediator.Send(new DeleteRoomTypeCommand(roomNumber));
        //     return types;
        //
        // }
    }
}
