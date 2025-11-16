using System;

namespace SK.FinalP.Domain.Entities;

public abstract class BaseEntityProposal : BaseEntityAsm
{
    public DateTime? RequestAt { get; set; }
    public int? RequestedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public int? ApprovedBy { get; set; }
    public Adm_User? RequestedByUser { get; set; }
    public Adm_User? ApprovedByUser { get; set; }
}
