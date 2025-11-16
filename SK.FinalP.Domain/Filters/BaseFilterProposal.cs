using System;

namespace SK.FinalP.Domain.Filters;

public abstract class BaseFilterProposal : BaseFilterAsm
{
    public DateTime? RequestAt { get; set; }
    public int? RequestedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public int? ApprovedBy { get; set; }
}
