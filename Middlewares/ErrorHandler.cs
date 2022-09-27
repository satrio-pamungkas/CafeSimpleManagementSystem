using System.Net;
using CafeSimpleManagementSystem.Helpers;
using CafeSimpleManagementSystem.Wrappers;

namespace CafeSimpleManagementSystem.Middlewares;

public class ErrorHandler
{
    private readonly RequestDelegate _next;

    public ErrorHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {   
            var response = context.Response;

            switch(error)
            {
                case AppException err:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException err:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var payload = new Response<object>()
            {
                Status = response.StatusCode,
                Message = error?.Message
            };
            await response.WriteAsJsonAsync(payload);
        }
    }
}