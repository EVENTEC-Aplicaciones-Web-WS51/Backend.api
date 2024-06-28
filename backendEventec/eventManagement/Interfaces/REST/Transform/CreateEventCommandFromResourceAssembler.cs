using backendEventec.eventManagement.Interfaces.REST.Resources;
using BDEventecFinal.eventManagement.Domain.Model.Commands;

namespace backendEventec.eventManagement.Interfaces.REST.Transform;

public static class CreateEventCommandFromResourceAssembler
{
    public static CreateEventCommand ToCommandFromResource(CreateEventResource resource) =>
        new(resource.NameEvent,resource.Type,resource.Description,resource.TotalTicket,resource.Status);
}