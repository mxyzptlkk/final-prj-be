using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class ProposalLiquidationService(IProposalLiquidationRepository repo) : IProposalLiquidationService
{
    private readonly IProposalLiquidationRepository _repo = repo;

    public async Task<ProposalLiquidationDto> GetPagedAsync(ProposalLiquidationDto dtoReq)
    {
        ProposalLiquidationDto dtoRes = new();
        (dtoRes.Proposals, dtoRes.PageSize) = await _repo.GetPagedAsync(dtoReq.Page!.Value, dtoReq.PageSize!.Value);

        return dtoRes;
    }
}
