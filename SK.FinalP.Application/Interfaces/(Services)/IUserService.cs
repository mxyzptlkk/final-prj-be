using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.Interfaces;

public interface IUserService
{
    Task<Adm_User?> GetAsync(int id);
    Task<IEnumerable<Adm_User>> GetAllAsync();
    Task<Adm_User> AddAsync(Adm_User user);
    Task<Adm_User> UpdateAsync(Adm_User user);
}
