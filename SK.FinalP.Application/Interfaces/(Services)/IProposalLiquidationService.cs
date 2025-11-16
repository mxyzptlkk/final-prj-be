using SK.FinalP.Application.DTOs;

namespace SK.FinalP.Application.Interfaces;

public interface IProposalLiquidationService
{
    Task<ProposalLiquidationDto> GetPagedAsync(ProposalLiquidationDto dtoReq);
}
