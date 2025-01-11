using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.ViewModels.Responses;

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
            File.WriteAllText("D:\\Logs.txt", $"Error occures: {ex.Message}");

            _logger.LogError(ex.Message);

            var response = new FailureResponseViewModel<bool>(ErrorCode.UnKnownError);

            // context.Response.StatusCode = 
            context.Response.WriteAsJsonAsync(response);
        }

        //return Task.CompletedTask;
    }
}