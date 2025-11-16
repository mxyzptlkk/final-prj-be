using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IProposalAcquisitionRepository
{
    Task<Asm_ProposalAcquisition?> GetAsync(int id);
    Task<(IEnumerable<Asm_ProposalAcquisition>, int)> GetPagedAsync(int page, int pageSize, ProposalAcquisitionFilter? filter = null);
    Task<Asm_ProposalAcquisition> AddAsync(Asm_ProposalAcquisition proposal);
    Task<Asm_ProposalAcquisition> UpdateAsync(Asm_ProposalAcquisition proposal);
}
