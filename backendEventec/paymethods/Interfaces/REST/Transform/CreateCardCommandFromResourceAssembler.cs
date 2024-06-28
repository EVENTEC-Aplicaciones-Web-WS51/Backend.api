using backendEventec.paymethods.Domain.Model.Commands;
using backendEventec.paymethods.Interfaces.REST.Resources;

namespace backendEventec.paymethods.Interfaces.REST.Transform;

public static class CreateCardCommandFromResourceAssembler
{
    public static CreateCardCommand ToCommandFromResource(CreateCardResource resource) => 
        new(resource.Number, resource.DueDate, resource.CssCode);
}