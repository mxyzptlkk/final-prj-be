using System.Collections.Generic;

namespace SK.FinalP.Domain.Entities;

public class Asm_ProposalLiquidation : BaseEntityProposal
{
    public ICollection<Asm_DetailLiquidation> Details { get; set; } = [];
}
