using SK.FinalP.Application.DTOs;

namespace SK.FinalP.Application.Interfaces;

public interface IAssetService
{
    Task<AssetDto> GetPagedAsync(AssetDto dtoReq);
}
