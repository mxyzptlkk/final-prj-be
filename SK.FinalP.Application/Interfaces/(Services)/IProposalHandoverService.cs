using SK.FinalP.Application.DTOs;

namespace SK.FinalP.Application.Interfaces;

public interface IProposalHandoverService
{
    Task<ProposalHandoverDto> GetPagedAsync(ProposalHandoverDto dtoReq);
}
