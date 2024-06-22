using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.paymethods.Domain.Repositories;

public interface IWalletRepository : IBaseRepository<Wallet>
{
    Task<IEnumerable<Wallet>> FindAllAsync();
    Task<Wallet?> FindByIdAsync(int id);
    Task<IEnumerable<Wallet>> FindByUserIdAsync(int userId);
}