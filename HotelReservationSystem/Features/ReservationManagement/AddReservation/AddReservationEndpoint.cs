using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Common;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Features.ReservationManagement.AddReservation.Commands;
using HotelReservationSystem.Features.ReservationManagement.Commands;
using HotelReservationSystem.Filters;
using HotelReservationSystem.ViewModels.Reservations;
using HotelReservationSystem.ViewModels.Responses;
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

        [HttpPost()]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments = new object[] { Feature.AddReservation })]
        public async Task<EndpointRespons<int>> Add(ReservationCreateRequestViewModel requestViewModel)
        {
            var command = requestViewModel.Map<AddReservationOrchestrator>();
            var response = await _mediator.Send(command);


            return response.Map<EndpointRespons<int>>();
        }
    }
}
