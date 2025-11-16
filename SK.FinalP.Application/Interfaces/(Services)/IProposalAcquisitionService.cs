using SK.FinalP.Application.DTOs;

namespace SK.FinalP.Application.Interfaces;

public interface IProposalAcquisitionService
{
    Task<ProposalAcquisitionDto> GetPagedAsync(ProposalAcquisitionDto dtoReq);
}
