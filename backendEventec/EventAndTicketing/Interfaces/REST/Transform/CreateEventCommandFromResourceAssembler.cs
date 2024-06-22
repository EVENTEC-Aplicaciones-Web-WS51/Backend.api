using backendEventec.EventAndTicketing.Domain.Model.Commands;
using backendEventec.EventAndTicketing.Interfaces.REST.Resources;

namespace backendEventec.EventAndTicketing.Interfaces.REST.Transform;

public static class CreateEventCommandFromResourceAssembler
{
    public static CreateEventCommand ToCommandFromResource(CreateEventResource resource) =>
        new CreateEventCommand(resource.Name, resource.Description, resource.Status);
}