using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class ProposalAcquisitionDto : BaseDto
{
    public IEnumerable<Asm_ProposalAcquisition> Proposals { get; set; } = [];
}
