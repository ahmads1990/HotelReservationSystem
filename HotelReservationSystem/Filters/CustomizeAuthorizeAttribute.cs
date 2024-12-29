using Azure.Core;
using FOOD_APP_JSB_2.CQRS.UserFeatures.Queries;
using FOOD_APP_JSB_2.Data.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace FOOD_APP_JSB_2.Filters
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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var claims = context.HttpContext.User;
             
            var userID = claims.FindFirst("ID");

            if (userID is null || string.IsNullOrEmpty(userID.Value))
            {
                throw new UnauthorizedAccessException();
            }

            var user = int.Parse(userID.Value);


            var hasAccess = _mediator.Send(new HasAccessQuery(user, _feature)).GetAwaiter().GetResult();

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(context);
        }
    }
}
