using backendEventec.paymethods.Domain.Model.Commands;
using backendEventec.paymethods.Interfaces.REST.Resources;

namespace backendEventec.paymethods.Interfaces.REST.Transform;

public static class CreateWalletCommandFromResourceAssembler
{
    public static CreateWalletCommand ToCommandFromResource(CreateWalletResource resource) => 
        new(resource.QuantityCard, resource.UserId);
}