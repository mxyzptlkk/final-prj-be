using SK.FinalP.Shared;

namespace SK.FinalP.Domain.Filters;

public class AssetFilter : BaseFilterAsm
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public Enums.AssetStatus? Status { get; set; }
    public int? CategoryId { get; set; }
    public int? OwnerId { get; set; }
}
