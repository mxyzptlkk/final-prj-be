using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Domain.Filters;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Context;

namespace SK.FinalP.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Adm_User?> GetAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }
    public async Task<IEnumerable<Adm_User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }
    public async Task<(IEnumerable<Adm_User>, int)> GetPagedAsync(int page, int pageSize, UserFilter? filter)
    {
        DbSet<Adm_User> query = _context.User;
        int totalCount = await query.CountAsync();
        IEnumerable<Adm_User> records = await query
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalCount);
    }
    public async Task<Adm_User> AddAsync(Adm_User User)
    {
        await _context.User.AddAsync(User);
        await _context.SaveChangesAsync();

        return User;
    }
    public async Task<Adm_User> UpdateAsync(Adm_User User)
    {
        _context.User.Update(User);
        await _context.SaveChangesAsync();

        return User;
    }
}
