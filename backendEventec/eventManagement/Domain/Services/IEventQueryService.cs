using BDEventecFinal.eventManagement.Domain.Model.Aggregates;
using BDEventecFinal.eventManagement.Domain.Model.Queries;

namespace backendEventec.eventManagement.Domain.Services;

public interface IEventQueryService
{
    Task<IEnumerable<Event>> Handle(GetAllEventQuery query);
    Task<Event?> Handle(GetEventByIdQuery query);
    Task<Event?> Handle(GetEventByNameQuery query);
    Task<Event?> Handle(GetEventByTypeQuery query);
}