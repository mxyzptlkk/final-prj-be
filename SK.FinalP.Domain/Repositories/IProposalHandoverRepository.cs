using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IProposalHandoverRepository
{
    Task<Asm_ProposalHandover?> GetAsync(int id);
    Task<(IEnumerable<Asm_ProposalHandover>, int)> GetPagedAsync(int page, int pageSize, ProposalHandoverFilter? filter = null);
    Task<Asm_ProposalHandover> AddAsync(Asm_ProposalHandover proposal);
    Task<Asm_ProposalHandover> UpdateAsync(Asm_ProposalHandover proposal);
}
