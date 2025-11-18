using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SK.FinalP.WebApi.Helpers;

namespace SK.FinalP.WebApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class JwtAuthorizeAttribute(bool requireToken = true) : Attribute, IAsyncActionFilter
{
    private readonly bool _requireToken = requireToken;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!_requireToken)
        {
            await next();

            return;
        }

        var token = context.HttpContext.Request.Headers.Authorization
            .FirstOrDefault()
            ?.Replace("Bearer ", string.Empty);

        if (string.IsNullOrWhiteSpace(token))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            return;
        }

        var jwtHelper = context.HttpContext.RequestServices.GetRequiredService<IJwtHelper>();
        var principal = jwtHelper.ValidateToken(token);

        if (principal == null)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            return;
        }

        context.HttpContext.User = principal;

        await next();
    }
}
