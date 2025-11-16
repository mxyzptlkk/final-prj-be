using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class AssetRepository(AppDbContext context) : IAssetRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Asm_Asset?> GetAsync(int id)
    {
        return await _context.Asset.FindAsync(id);
    }
    public async Task<(IEnumerable<Asm_Asset>, int)> GetPagedAsync(int page, int pageSize, AssetFilter? filter)
    {
        DbSet<Asm_Asset> query = _context.Asset;
        int totalCount = await query.CountAsync();
        IEnumerable<Asm_Asset> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Asm_Asset> AddAsync(Asm_Asset asset)
    {
        await _context.Asset.AddAsync(asset);
        await _context.SaveChangesAsync();

        return asset;
    }
    public async Task<Asm_Asset> UpdateAsync(Asm_Asset asset)
    {
        _context.Asset.Update(asset);
        await _context.SaveChangesAsync();

        return asset;
    }
}
