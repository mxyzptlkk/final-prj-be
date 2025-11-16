using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class UserDto : BaseDto
{
    public Adm_User? User { get; set; }
    public IEnumerable<Adm_User> Users { get; set; } = [];
}
