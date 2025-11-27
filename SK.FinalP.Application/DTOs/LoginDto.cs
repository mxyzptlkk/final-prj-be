namespace SK.FinalP.Application.DTOs;

public class LoginDto : BaseDto
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    
}
