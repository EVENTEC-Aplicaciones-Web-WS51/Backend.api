using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.paymethods.Infrastructure.Persistence.EFC.Repositories;

public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
{
    public WalletRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Wallet>> FindAllAsync()
    {
        return await Context.Set<Wallet>().ToListAsync();
    }

    public  async Task<Wallet?> FindByIdAsync(int id)
    {
        return await Context.Set<Wallet>().FindAsync(id);
    }

    public async Task<IEnumerable<Wallet>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Wallet>().Where(c => c.UserId == userId).ToListAsync();
    }
}
