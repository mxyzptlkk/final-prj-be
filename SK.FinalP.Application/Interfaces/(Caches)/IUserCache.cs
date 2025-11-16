using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.Interfaces;

public interface IUserCache
{
    Task<Adm_User?> GetAsync(int id);
    Task<List<Adm_User>> GetAllAsync();
    Task SetAsync(Adm_User user);
    Task SetAllAsync(IEnumerable<Adm_User> users);
    Task RemoveAsync(int id);
}
