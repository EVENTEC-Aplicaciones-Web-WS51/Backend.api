using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Queries;

namespace backendEventec.EventAndTicketing.Domain.Services;

public interface IEventQueryService
{
    Task<IEnumerable<Event>> Handle(GetAllEventQuery query);
    Task<Event?> Handle(GetEventByIdQuery query);
    Task<IEnumerable<Event>> Handle(GetEventByHeadquarters query);
    Task<IEnumerable<Event>> Handle(GetEventByOrganizerIdQuery query);
}