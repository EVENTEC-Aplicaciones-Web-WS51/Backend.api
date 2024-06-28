using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.paymethods.Domain.Repositories
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> FindAllAsync();
        Task<Card?> FindByIdAsync(int id);
        Task<IEnumerable<Card>> FindByWalletIdAsync(int idWallet);
    }
}