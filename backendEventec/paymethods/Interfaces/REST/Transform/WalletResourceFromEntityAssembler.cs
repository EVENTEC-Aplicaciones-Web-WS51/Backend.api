using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Interfaces.REST.Resources;

namespace backendEventec.paymethods.Interfaces.REST.Transform;

public class WalletResourceFromEntityAssembler
{
    public static WalletResource ToResourceFromEntity(Wallet entity) =>
        new WalletResource(entity.Id, entity.QuantityCard, entity.CreationDate, entity.UserId);
}