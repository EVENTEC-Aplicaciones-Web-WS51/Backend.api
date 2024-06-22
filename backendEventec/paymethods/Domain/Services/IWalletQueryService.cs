using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Queries;

namespace backendEventec.paymethods.Domain.Services;

public interface IWalletQueryService
{
    Task<IEnumerable<Wallet>> Handle(GetAllWalletsQuery query);
    Task<Wallet?> Handle(GetWalletByIdQuery query);
    Task<IEnumerable<Wallet>> Handle(GetWalletsByUserIdQuery query);
}