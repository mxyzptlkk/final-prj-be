using System.Collections.Generic;
using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;

namespace SK.FinalP.Domain.Repositories;

public interface IUserRepository
{
    Task<Adm_User?> GetAsync(int id);
    Task<IEnumerable<Adm_User>> GetAllAsync();
    Task<(IEnumerable<Adm_User>, int)> GetPagedAsync(int page, int pageSize, UserFilter? filter = null);
    Task<Adm_User> AddAsync(Adm_User User);
    Task<Adm_User> UpdateAsync(Adm_User User);
}
