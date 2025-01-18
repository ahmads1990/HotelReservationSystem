using HotelReservationSystem.Common.views;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HotelReservationSystem.Features.ReservationManagement.AddReservation;

    [ApiController]
    [Route("[controller]/[action]")]
    public class AddReservationEndpoint : ControllerBase
    {
        readonly IMediator _mediator;
        public AddReservationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<EndpointRespons<int>> Add(ReservationCreateRequestViewModel requestViewModel)
        {
            
            var command = new AddReservationOrchestrator(requestViewModel.MainGuestNID, requestViewModel.TotalAmount, requestViewModel.ReservationRooms);
            var response = await _mediator.Send(command);


            return EndpointRespons<int>.Success(response.data);
        }
        
        [HttpPost]
        public async Task<EndpointRespons<int>> AddResrvation(ReservationCreateRequestViewModel requestViewModel)
        {
            
            var command = new AddReservationOrchestrator(requestViewModel.MainGuestNID, requestViewModel.TotalAmount, requestViewModel.ReservationRooms);
            var response = await _mediator.Send(command);


            return EndpointRespons<int>.Success(response.data);
        }
    }

