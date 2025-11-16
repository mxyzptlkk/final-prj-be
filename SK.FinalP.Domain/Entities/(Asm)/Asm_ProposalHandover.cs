using System.Collections.Generic;

namespace SK.FinalP.Domain.Entities;

public class Asm_ProposalHandover : BaseEntityProposal
{
    public ICollection<Asm_DetailHandover> Details { get; set; } = [];
    
}
