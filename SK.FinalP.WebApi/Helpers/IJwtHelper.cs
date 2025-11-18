using System.Collections.Generic;
using System.Security.Claims;

namespace SK.FinalP.WebApi.Helpers;

public interface IJwtHelper
{
    string GenerateToken(Dictionary<string, string> claims);
    ClaimsPrincipal? ValidateToken(string token);
}
