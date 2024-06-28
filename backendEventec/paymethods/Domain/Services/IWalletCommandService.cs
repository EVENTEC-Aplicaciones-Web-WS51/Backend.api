using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Commands;

namespace backendEventec.paymethods.Domain.Services;

public interface IWalletCommandService
{
    Task<Wallet?> Handle(CreateWalletCommand command);
}