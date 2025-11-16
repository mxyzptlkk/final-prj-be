using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class ProposalHandoverService(IProposalHandoverRepository repo) : IProposalHandoverService
{
    private readonly IProposalHandoverRepository _repo = repo;

    public async Task<ProposalHandoverDto> GetPagedAsync(ProposalHandoverDto dtoReq)
    {
        ProposalHandoverDto dtoRes = new();
        (dtoRes.Proposals, dtoRes.PageSize) = await _repo.GetPagedAsync(dtoReq.Page!.Value, dtoReq.PageSize!.Value);

        return dtoRes;
    }
}
