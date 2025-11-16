using System.Collections.Generic;

namespace SK.FinalP.Domain.Entities;

public class Asm_ProposalAcquisition : BaseEntityProposal
{
    public ICollection<Asm_DetailAcquisition> Details { get; set; } = [];
}
