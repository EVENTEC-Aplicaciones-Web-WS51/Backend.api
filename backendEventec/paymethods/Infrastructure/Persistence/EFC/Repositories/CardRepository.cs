using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.paymethods.Infrastructure.Persistence.EFC.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Card>> FindAllAsync()
        {
            return await Context.Set<Card>().ToListAsync();
        }

        public  async Task<Card?> FindByIdAsync(int id)
        {
            return await Context.Set<Card>().FindAsync(id);
        }

        public async Task<IEnumerable<Card>> FindByWalletIdAsync(int idWallet)
        {
            return await Context.Set<Card>().Where(c => c.IdWallet == idWallet).ToListAsync();
        }
    }
}

