using System.Collections.Generic;

namespace SK.FinalP.Domain.Entities;

public class Asm_ProposalTransfer : BaseEntityProposal
{
    public ICollection<Asm_DetailTransfer> Details { get; set; } = [];
}
