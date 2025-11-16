using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IProposalTransferRepository
{
    Task<Asm_ProposalTransfer?> GetAsync(int id);
    Task<(IEnumerable<Asm_ProposalTransfer>, int)> GetPagedAsync(int page, int pageSize, ProposalTransferFilter? filter = null);
    Task<Asm_ProposalTransfer> AddAsync(Asm_ProposalTransfer proposal);
    Task<Asm_ProposalTransfer> UpdateAsync(Asm_ProposalTransfer proposal);
}
