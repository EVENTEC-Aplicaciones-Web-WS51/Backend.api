using backendEventec.paymethods.Interfaces.REST.Resources;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Interfaces.REST.Transform;

public class CardResourceFromEntityAssembler
{
    public static CardResource ToResourceFromEntity(Card entity) =>
        new CardResource(entity.Id, entity.IdWallet, entity.Number, entity.DueDate, entity.CssCode);
}