using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.UserManagement.Infrastructure.Persistence.EFC.Repositories;

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

    public async Task<IEnumerable<User>> FindByWalletIdAsync(int idWallet)
    {
        return await Context.Set<User>().Where(c => c.IdWallet == idWallet).ToListAsync();
    }
}