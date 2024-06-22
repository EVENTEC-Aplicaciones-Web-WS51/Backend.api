using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Interfaces.REST.Resources;

namespace backendEventec.EventAndTicketing.Interfaces.REST.Transform;

public class TicketResourceFromEntityAssembler
{
    public static TicketResource ToResourceFromEntity(Ticket entity) =>
        new TicketResource(entity.Id, entity.EventId, entity.ClientId, entity.Price, entity.Category);
}