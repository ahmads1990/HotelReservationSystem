using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries.GetAllRoom;
using HotelReservationSystem.Filters;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.RabbitMQ;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservations;
using HotelReservationSystem.ViewModels.Responses;
using HotelReservationSystem.ViewModels.RoomManagment.RoomTypes;
using HotelReservationSystem.ViewModels.RoomManagment.RTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotelReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservationController : ControllerBase
    {
        readonly IMediator _mediator;
        RabbitMQPuublisherService _rabbitMqPuublisherService;
        
        public ReservationController(IMediator mediator, RabbitMQPuublisherService rabbitMqPuublisherService)
        {
            _mediator = mediator;
            _rabbitMqPuublisherService = rabbitMqPuublisherService;
        }

        [HttpPost()]
        public async Task<ResponseViewModel<int>> Add(ReservationCreateViewModel viewModel)
        {
            var command = viewModel.Map<CreateReservationCommand>();
            var response = await _mediator.Send(command);
 
            return new  SuccessResponseViewModel<int>(response.Data);
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
        
        [HttpGet("GetAllRoomsType")]
        public async Task<ResponseDTO> GetAllRoomsType()
        {
            var response = await _mediator.Send(new GetAllRoomTypeQuery());
            
            await _rabbitMqPuublisherService.Publish("message");
            return response;
        }
        
        [HttpPut]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.DeleteRoomType })]
        public async Task<ResponseViewModel<bool>> DeleteRoomType(string roomNumber)
        {
            var types = await _mediator.Send(new DeleteRoomTypeCommand(roomNumber));
            return types;

        }
    }
}
