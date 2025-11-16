using SK.FinalP.Application.DTOs;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class AssetServices(IAssetRepository repo) : IAssetService
{
    private readonly IAssetRepository _repo = repo;

    public async Task<AssetDto> GetPagedAsync(AssetDto dtoReq)
    {
        if (!dtoReq.Page.HasValue || !dtoReq.PageSize.HasValue)
            throw new Exception();

        AssetDto dtoRes = new();

        (dtoRes.Assets, dtoRes.PageSize) = await _repo.GetPagedAsync(dtoReq.Page!.Value, dtoReq.PageSize!.Value);

        return dtoRes;
    }
}
