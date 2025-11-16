using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class ProposalLiquidationDto : BaseDto
{
    public IEnumerable<Asm_ProposalLiquidation> Proposals { get; set; } = [];
}
