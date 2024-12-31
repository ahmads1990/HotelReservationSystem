using Azure.Core;
using HotelReservationSystem.Features.UserManagement.UserFeatures.Queries;
using HotelReservationSystem.Data.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace HotelReservationSystem.Filters
{
    public class CustomizeAuthorizeAttribute : ActionFilterAttribute
    {
        
        Feature _feature;
        IMediator _mediator;

        public CustomizeAuthorizeAttribute(Feature feature, IMediator mediator)
        {
            _feature = feature;
            _mediator = mediator;
        }

        
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var claims = context.HttpContext.User;
            var userID = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userID is null || string.IsNullOrEmpty(userID))
            {
                throw new UnauthorizedAccessException();
            }

            var user = int.Parse(userID);

            // Await the asynchronous call
            var hasAccess = await _mediator.Send(new HasAccessQuery(user, _feature));

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }

            // Proceed to the next action
            await base.OnActionExecutionAsync(context, next);
        }

    }
}
