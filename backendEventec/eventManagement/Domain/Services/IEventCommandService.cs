using BDEventecFinal.eventManagement.Domain.Model.Aggregates;
using BDEventecFinal.eventManagement.Domain.Model.Commands;

namespace backendEventec.eventManagement.Domain.Services;

public interface IEventCommandService
{
    Task<Event?> Handle(CreateEventCommand command);
}