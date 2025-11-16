namespace SK.FinalP.Domain.Entities;

public abstract class BaseEntityDetail : BaseEntityAsm
{
    public int ProposalId { get; set; }
    public int AssetId { get; set; }
    public Asm_Asset? Asset { get; set; }
}
