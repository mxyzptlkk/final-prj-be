namespace SK.FinalP.Domain.Filters;

public class UserFilter : BaseFilter
{
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    public bool? IsActive { get; set; }
    public int? CreatedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
}
