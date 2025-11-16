namespace SK.FinalP.Domain.Filters;

public abstract class BaseFilterAsm : BaseFilter
{
    public int? CreatedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
}
