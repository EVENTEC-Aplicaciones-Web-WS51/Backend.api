using backendEventec.eventManagement.Interfaces.REST.Resources;
using BDEventecFinal.eventManagement.Domain.Model.Aggregates;

namespace backendEventec.eventManagement.Interfaces.REST.Transform;

public static class EventResourceFromEntityAssembler
{
    public static EventResource ToResourceFromEntity(Event entity) =>
        new EventResource(entity.IdEvent, entity.NameEvent, entity.Type, entity.Description, entity.TotalTicket, entity.Status);
}