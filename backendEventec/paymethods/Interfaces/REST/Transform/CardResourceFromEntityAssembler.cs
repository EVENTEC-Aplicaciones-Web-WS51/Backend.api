using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Interfaces.REST.Resources;

namespace backendEventec.paymethods.Interfaces.REST.Transform;

public class CardResourceFromEntityAssembler
{
    public static CardResource ToResourceFromEntity(Card entity) =>
        new CardResource(entity.Id, entity.IdWallet, entity.Number, entity.DueDate, entity.CssCode);
}