using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class ProposalTransferDto : BaseDto
{
    public IEnumerable<Asm_ProposalTransfer> Proposals { get; set; } = [];
}
