using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class ProposalAcquisitionRepository(AppDbContext context) : IProposalAcquisitionRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Asm_ProposalAcquisition?> GetAsync(int id)
    {
        return await _context.ProposalAcquisition.FindAsync(id);
    }
    public async Task<(IEnumerable<Asm_ProposalAcquisition>, int)> GetPagedAsync(int page, int pageSize, ProposalAcquisitionFilter? filter)
    {
        DbSet<Asm_ProposalAcquisition> query = _context.ProposalAcquisition;
        int totalCount = await query.CountAsync();
        IEnumerable<Asm_ProposalAcquisition> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Asm_ProposalAcquisition> AddAsync(Asm_ProposalAcquisition proposal)
    {
        await _context.ProposalAcquisition.AddAsync(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
    public async Task<Asm_ProposalAcquisition> UpdateAsync(Asm_ProposalAcquisition proposal)
    {
        _context.ProposalAcquisition.Update(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
}
