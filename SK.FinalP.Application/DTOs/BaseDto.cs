namespace SK.FinalP.Application.DTOs;

public abstract class BaseDto
{
    public int? Id { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}
