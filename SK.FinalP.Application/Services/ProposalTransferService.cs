using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class ProposalTransferService(IProposalTransferRepository repo): IProposalTransferService
{
    private readonly IProposalTransferRepository _repo = repo;

    public async Task<ProposalTransferDto> GetPagedAsync(ProposalTransferDto dtoReq)
    {
        ProposalTransferDto dtoRes = new();
        (dtoRes.Proposals, dtoRes.PageSize) = await _repo.GetPagedAsync(dtoReq.Page!.Value, dtoReq.PageSize!.Value);

        return dtoRes;
    }
}
