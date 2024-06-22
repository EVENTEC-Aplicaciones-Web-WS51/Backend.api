using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Queries;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.paymethods.Domain.Services;

namespace backendEventec.paymethods.Application.Internal.QueriesServices;

public class WalletQueryService(IWalletRepository walletRepository) : IWalletQueryService
{
    public async Task<IEnumerable<Wallet>> Handle(GetAllWalletsQuery query)
    {
        return await walletRepository.FindAllAsync();
    }

    public async Task<Wallet?> Handle(GetWalletByIdQuery query)
    {
        return await walletRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Wallet>> Handle(GetWalletsByUserIdQuery query)
    {
        return await walletRepository.FindByUserIdAsync(query.UserId);
    }
}