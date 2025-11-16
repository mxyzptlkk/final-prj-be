using System;

namespace SK.FinalP.Domain.Filters;

public abstract class BaseFilter
{
    public int? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public int? Version { get; set; }
    public bool? IsNotDeleted { get; set; }
}
