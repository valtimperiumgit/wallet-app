using System.Text.Json;
using ApplicationException = WalletApp.Application.Core.Exceptions.ApplicationException; 

namespace WalletApp.Api.Middleware;

public class ApplicationExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ApplicationExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApplicationException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { error = exception.Message });
            await context.Response.WriteAsync(result);
        }
    }
}