using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class ProposalHandoverDto : BaseDto
{
    public IEnumerable<Asm_ProposalHandover> Proposals { get; set; } = [];
}
