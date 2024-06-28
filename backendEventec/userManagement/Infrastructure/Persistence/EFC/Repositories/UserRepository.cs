using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.userManagement.Domain.Repositories;
using BDEventecFinal.userManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.userManagement.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> FindAllAsync()
    {
        return await Context.Set<User>().ToListAsync();
    }
    public  async Task<User?> FindByIdAsync(int id)
    {
        return await Context.Set<User>().FindAsync(id);
    }
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }
    
}