using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;
using HotelReservationSystem.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotelReservationSystem.Features.ReservationManagement.AddReservation
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AddReservationEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddReservationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        // [Authorize]
        // [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.AddReservation })]
        public async Task<EndpointRespons<int>> Add(ReservationCreateRequestViewModel requestViewModel)
        {
            
            var command = new AddReservationOrchestrator(requestViewModel.MainGuestNID, requestViewModel.TotalAmount, requestViewModel.ReservationRooms);
            var response = await _mediator.Send(command);


            return EndpointRespons<int>.Success(response.data);
        }
    }
}
