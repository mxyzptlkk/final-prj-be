using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;

namespace SK.FinalP.WebApi.Controllers;

[Route("/api/[controller]")]
public class UserController(IUserService service)
{
    private readonly IUserService _service = service;

    [HttpGet("{id:int}")]
    public async Task<UserDto> UserByID(int id)
    {
        UserDto dtoRes = new()
        {
            User = await _service.GetAsync(id)
        };

        return dtoRes;
    }
}
