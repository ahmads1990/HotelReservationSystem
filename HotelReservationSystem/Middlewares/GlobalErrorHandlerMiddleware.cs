using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;


namespace HotelReservationSystem.Middlewares;

public class GlobalErrorHandlerMiddleware
{
    RequestDelegate _nextAction;
    ILogger<GlobalErrorHandlerMiddleware> _logger;
    public GlobalErrorHandlerMiddleware(RequestDelegate nextAction, 
        ILogger<GlobalErrorHandlerMiddleware> logger)
    {
        _nextAction = nextAction;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _nextAction(context);
        }
        catch (Exception ex)
        {
            var response = EndpointRespons<bool>.Failed<bool>(ErrorCode.UnKnownError);
            context.Response.WriteAsJsonAsync(response);
        }

        //return Task.CompletedTask;
    }
}