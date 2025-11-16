using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class ProposalLiquidationRepository(AppDbContext context) : IProposalLiquidationRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Asm_ProposalLiquidation?> GetAsync(int id)
    {
        return await _context.ProposalLiquidation.FindAsync(id);
    }
    public async Task<(IEnumerable<Asm_ProposalLiquidation>, int)> GetPagedAsync(int page, int pageSize, ProposalLiquidationFilter? filter)
    {
        DbSet<Asm_ProposalLiquidation> query = _context.ProposalLiquidation;
        int totalCount = await query.CountAsync();
        IEnumerable<Asm_ProposalLiquidation> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Asm_ProposalLiquidation> AddAsync(Asm_ProposalLiquidation proposal)
    {
        await _context.ProposalLiquidation.AddAsync(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
    public async Task<Asm_ProposalLiquidation> UpdateAsync(Asm_ProposalLiquidation proposal)
    {
        _context.ProposalLiquidation.Update(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
}
