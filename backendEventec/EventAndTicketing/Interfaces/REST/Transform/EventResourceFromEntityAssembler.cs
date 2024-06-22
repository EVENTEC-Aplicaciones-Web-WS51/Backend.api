using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Interfaces.REST.Resources;

namespace backendEventec.EventAndTicketing.Interfaces.REST.Transform;

public class EventResourceFromEntityAssembler
{
    public static EventResource ToResourceFromEntity(Event entity) =>
        new EventResource(entity.Id, entity.IdHeadquarters, entity.IdOrganizer, entity.Name, entity.StartDate, entity.FinishDate, entity.Description, entity.TotalTicket,
            entity.Status);
}