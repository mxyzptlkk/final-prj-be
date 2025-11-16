using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class ProposalAcquisitionService(IProposalAcquisitionRepository repo) : IProposalAcquisitionService
{
    private readonly IProposalAcquisitionRepository _repo = repo;

    public async Task<ProposalAcquisitionDto> GetPagedAsync(ProposalAcquisitionDto dtoReq)
    {
        ProposalAcquisitionDto dtoRes = new();
        (dtoRes.Proposals, dtoRes.PageSize) = await _repo.GetPagedAsync(dtoReq.Page!.Value, dtoReq.PageSize!.Value);

        return dtoRes;
    }
}
