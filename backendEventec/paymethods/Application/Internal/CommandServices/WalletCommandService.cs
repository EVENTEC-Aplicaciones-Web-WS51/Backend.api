using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Commands;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.paymethods.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.paymethods.Application.Internal.CommandServices;

public class WalletCommandService(IWalletRepository walletRepository, IUnitOfWork unitOfWork) : 
    IWalletCommandService
{
    public async Task<Wallet?> Handle(CreateWalletCommand command)
    {
        var wallet = new Wallet(command);
        try
        {
            await walletRepository.AddAsync(wallet);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return wallet;
    }
}