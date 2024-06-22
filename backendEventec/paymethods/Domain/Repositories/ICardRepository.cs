using backendEventec.Shared.Domain.Repositories;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Domain.Repositories
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<IEnumerable<Card>> FindAllAsync();
        Task<Card?> FindByIdAsync(int id);
        Task<IEnumerable<Card>> FindByWalletIdAsync(int idWallet);
    }
}