using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Shared.Utils;

namespace SK.FinalP.WebApi.Helpers;

public sealed class ProfileHelper(IHttpContextAccessor http, IUserService _service) : IProfileHelper
{
    private readonly IHttpContextAccessor _http = http;
    private readonly IUserService _userService = _service;

    public async Task<Adm_User> GetUser()
    {
        var userClaims = (_http.HttpContext?.User)
            ?? throw new Exception("User claims not found in HTTP context.");

        int? userIdClaim = (userClaims.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value.ToIntOrNull())
            ?? throw new Exception("Required user claims are missing.");

        return await _userService.GetAsync(userIdClaim.Value)
            ?? throw new Exception("User not found.");
    }
}