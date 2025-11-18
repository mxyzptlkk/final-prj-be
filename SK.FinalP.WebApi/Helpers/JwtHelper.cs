using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SK.FinalP.Shared.Utils;

namespace SK.FinalP.WebApi.Helpers;

public sealed class JwtHelper(IConfiguration config) : IJwtHelper
{
    private readonly string _key = config["Jwt:Key"]!;
    private readonly string _issuer = config["Jwt:Issuer"]!;
    private readonly string _audience = config["Jwt:Audience"]!;
    private readonly int _expiryMinutes = config["Jwt:ExpiryMinutes"].ToIntOrNull()!.Value;

    public string GenerateToken(Dictionary<string, string> claims)
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenClaims = claims.Select(static x => new Claim(x.Key, x.Value)).ToList();

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: tokenClaims,
            expires: DateTime.Now.AddMinutes(_expiryMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(_key);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            return principal;
        }
        catch
        {
            throw new UnauthorizedAccessException("Invalid token.");
        }
    }
}
