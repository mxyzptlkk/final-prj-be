using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Repositories;

namespace SK.FinalP.Application.Services;

public class UserService(IUserRepository repo, IUserCache cache) : IUserService
{
    private readonly IUserRepository _repo = repo;
    private readonly IUserCache _cache = cache;

    public async Task<Adm_User?> GetAsync(int id)
    {
        var cachedUser = await _cache.GetAsync(id);

        if (cachedUser != null)
            return cachedUser;

        var user = await _repo.GetAsync(id);

        if (user != null)
            await _cache.SetAsync(user!);

        return user;
    }
    public async Task<IEnumerable<Adm_User>> GetAllAsync()
    {
        var cachedUsers = await _cache.GetAllAsync();

        if (cachedUsers.Count != 0)
            return cachedUsers;

        var users = await _repo.GetAllAsync();

        if (users.Any())
            await _cache.SetAllAsync(users);

        return users;
    }
    public async Task<Adm_User> AddAsync(Adm_User user)
    {
        var addedUser = await _repo.AddAsync(user);
        await _cache.SetAsync(addedUser);

        return addedUser;
    }
    public async Task<Adm_User> UpdateAsync(Adm_User user)
    {
        var updatedUser = await _repo.UpdateAsync(user);
        await _cache.RemoveAsync(updatedUser.Id);
        await _cache.SetAsync(updatedUser);

        return updatedUser;
    }
}
