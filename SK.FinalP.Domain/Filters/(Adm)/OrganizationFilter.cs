namespace SK.FinalP.Domain.Filters;

public class OrganizationFilter : BaseFilter
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public int? ParentId { get; set; }
}
