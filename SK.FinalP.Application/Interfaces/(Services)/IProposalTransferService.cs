using SK.FinalP.Application.DTOs;

namespace SK.FinalP.Application.Interfaces;

public interface IProposalTransferService
{
    Task<ProposalTransferDto> GetPagedAsync(ProposalTransferDto dtoReq);
}
