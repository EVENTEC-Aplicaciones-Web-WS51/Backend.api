using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public class OrganizerResourceFromEntityAssembler
{
    public static OrganizerResource ToResourceFromEntity(Organizer entity) =>
        new OrganizerResource(entity.Id, entity.CompanyName, entity.UserId, entity.EventsInCharge);
}