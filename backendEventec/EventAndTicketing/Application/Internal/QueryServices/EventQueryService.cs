using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Queries;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.EventAndTicketing.Domain.Services;

namespace backendEventec.EventAndTicketing.Application.Internal.QueryServices;

public class EventQueryService(IEventRepository eventRepository) : IEventQueryService
{
    public async Task<IEnumerable<Event>> Handle(GetAllEventQuery query)
    {
        return await eventRepository.FindByAllEventAsync();
    }

    public async Task<Event?> Handle(GetEventByIdQuery query)
    {
        return await eventRepository.FindByEventIdAsync(query.Id);
    }

    public async Task<IEnumerable<Event>> Handle(GetEventByHeadquarters query)
    {
        return await eventRepository.FindByHeadquartersAsync(query.IdHeadquarters);
    }

    public async Task<IEnumerable<Event>> Handle(GetEventByOrganizerIdQuery query)
    {
        return await eventRepository.FindByOrganizerIdAsync(query.IdOrganizer);
    }
}
    
