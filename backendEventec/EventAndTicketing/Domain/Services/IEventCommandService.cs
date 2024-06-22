using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Commands;

namespace backendEventec.EventAndTicketing.Domain.Services;

public interface IEventCommandService
{
    Task<Event?> Handle(CreateEventCommand command);
}