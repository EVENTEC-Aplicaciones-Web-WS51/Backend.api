using backendEventec.eventManagement.Domain.Repositories;
using backendEventec.eventManagement.Domain.Services;
using BDEventecFinal.eventManagement.Domain.Model.Aggregates;
using BDEventecFinal.eventManagement.Domain.Model.Queries;

namespace backendEventec.eventManagement.Application.Internal.QueriesServices;

public class EventQueryService(IEventRepository eventRepository): IEventQueryService
{
    public async Task<IEnumerable<Event>> Handle(GetAllEventQuery query)
    {
        return await eventRepository.FindAllAsync();
    }

    public async Task<Event?> Handle(GetEventByIdQuery query)
    {
        return await eventRepository.FindByIdAsync(query.IdEvent);
    }
    public async Task<Event?> Handle(GetEventByNameQuery query)
    {
        return await eventRepository.FindByNameAsync(query.NameEvent);
    }
    public async Task<Event?> Handle(GetEventByTypeQuery query)
    {
        return await eventRepository.FindByTypeAsync(query.Type);
    }
    
}