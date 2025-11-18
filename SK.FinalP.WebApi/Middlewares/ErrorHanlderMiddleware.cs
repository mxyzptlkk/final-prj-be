using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SK.FinalP.Shared.Exceptions;

namespace SK.FinalP.WebApi.Middlewares;

public sealed class ErrorHanlderMiddleware(RequestDelegate next, ILogger<ErrorHanlderMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHanlderMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case UnauthorizedAccessException:
                    _logger.LogError(ex, "Unauthorized access error.");

                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized access.");

                    break;
                case ForbidenException:
                    _logger.LogError(ex, "Forbidden access error.");

                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden access.");

                    break;
                case BizException:
                    _logger.LogError(ex, "Business logic error.");

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(ex.Message);

                    break;
                default:
                    _logger.LogError(ex, "An unexpected error occurred.");

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An unexpected error occurred.");

                    break;
            }
        }
    }
}
