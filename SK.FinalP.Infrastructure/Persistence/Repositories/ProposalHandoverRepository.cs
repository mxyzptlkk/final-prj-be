using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class ProposalHandoverRepository(AppDbContext context) : IProposalHandoverRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Asm_ProposalHandover?> GetAsync(int id)
    {
        return await _context.ProposalHandover.FindAsync(id);
    }
    public async Task<(IEnumerable<Asm_ProposalHandover>, int)> GetPagedAsync(int page, int pageSize, ProposalHandoverFilter? filter)
    {
        DbSet<Asm_ProposalHandover> query = _context.ProposalHandover;
        int totalCount = await query.CountAsync();
        IEnumerable<Asm_ProposalHandover> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Asm_ProposalHandover> AddAsync(Asm_ProposalHandover proposal)
    {
        await _context.ProposalHandover.AddAsync(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
    public async Task<Asm_ProposalHandover> UpdateAsync(Asm_ProposalHandover proposal)
    {
        _context.ProposalHandover.Update(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
}
