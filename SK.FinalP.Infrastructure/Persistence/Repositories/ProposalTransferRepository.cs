using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class ProposalTransferRepository(AppDbContext context) : IProposalTransferRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Asm_ProposalTransfer?> GetAsync(int id)
    {
        return await _context.ProposalTransfer.FindAsync(id);
    }
    public async Task<(IEnumerable<Asm_ProposalTransfer>, int)> GetPagedAsync(int page, int pageSize, ProposalTransferFilter? filter)
    {
        DbSet<Asm_ProposalTransfer> query = _context.ProposalTransfer;
        int totalCount = await query.CountAsync();
        IEnumerable<Asm_ProposalTransfer> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Asm_ProposalTransfer> AddAsync(Asm_ProposalTransfer proposal)
    {
        await _context.ProposalTransfer.AddAsync(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
    public async Task<Asm_ProposalTransfer> UpdateAsync(Asm_ProposalTransfer proposal)
    {
        _context.ProposalTransfer.Update(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
}
