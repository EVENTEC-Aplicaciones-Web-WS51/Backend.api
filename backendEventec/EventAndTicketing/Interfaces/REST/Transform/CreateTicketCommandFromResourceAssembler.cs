using backendEventec.EventAndTicketing.Domain.Model.Commands;
using backendEventec.EventAndTicketing.Interfaces.REST.Resources;

namespace backendEventec.EventAndTicketing.Interfaces.REST.Transform;

public static class CreateTicketCommandFromResourceAssembler
{
    public static CreateTicketCommand ToCommandFromResource(CreateTicketResource resource) =>
        new CreateTicketCommand(resource.Price,resource.Category);
}