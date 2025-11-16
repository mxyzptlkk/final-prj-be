using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Entities;
using StackExchange.Redis;

namespace SK.FinalP.Infrastructure.Persistence.Caches;

public class UserCache(IConnectionMultiplexer redis) : IUserCache
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<Adm_User?> GetAsync(int id)
    {
        var user = await _db.HashGetAsync("users", id.ToString());

        return user.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Adm_User>(user!);
    }
    public async Task<List<Adm_User>> GetAllAsync()
    {
        var users = await _db.HashValuesAsync("users");

        return users
            .Select(x => JsonSerializer.Deserialize<Adm_User>(x!))
            .ToList()!;
    }
    public async Task SetAsync(Adm_User user)
    {
        var addedUser = JsonSerializer.Serialize(user);
        await _db.HashSetAsync("users", user.Id.ToString(), addedUser);
    }
    public async Task SetAllAsync(IEnumerable<Adm_User> users)
    {
        var addUsers = users
            .Select(x =>
            {
                var val = JsonSerializer.Serialize(x);

                return new HashEntry(x.Id.ToString(), val);
            })
            .ToArray();

        await _db.HashSetAsync("users", addUsers);
    }
    public async Task RemoveAsync(int id)
    {
        await _db.HashDeleteAsync("users", id.ToString());
    }
}
