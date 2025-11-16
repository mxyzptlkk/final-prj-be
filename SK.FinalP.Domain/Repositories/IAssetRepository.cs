using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IAssetRepository
{
    Task<Asm_Asset?> GetAsync(int id);
    Task<(IEnumerable<Asm_Asset>, int)> GetPagedAsync(int page, int pageSize, AssetFilter? filter = null);
    Task<Asm_Asset> AddAsync(Asm_Asset asset);
    Task<Asm_Asset> UpdateAsync(Asm_Asset asset);
}
