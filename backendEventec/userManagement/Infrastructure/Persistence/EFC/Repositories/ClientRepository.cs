using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.UserManagement.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository: BaseRepository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> FindAllAsync()
    {
        return await Context.Set<Client>().ToListAsync();
    }

    public async Task<Client?> FindByIdAsync(int id)
    {
        return await Context.Set<Client>().FindAsync(id);
    }

    public async Task<IEnumerable<Client>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Client>().Where(c => c.UserId == userId).ToListAsync();
    }
}