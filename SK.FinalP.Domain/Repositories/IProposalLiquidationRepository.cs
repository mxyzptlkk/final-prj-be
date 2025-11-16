using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IProposalLiquidationRepository
{
    Task<Asm_ProposalLiquidation?> GetAsync(int id);
    Task<(IEnumerable<Asm_ProposalLiquidation>, int)> GetPagedAsync(int page, int pageSize, ProposalLiquidationFilter? filter = null);
    Task<Asm_ProposalLiquidation> AddAsync(Asm_ProposalLiquidation proposal);
    Task<Asm_ProposalLiquidation> UpdateAsync(Asm_ProposalLiquidation proposal);
}
