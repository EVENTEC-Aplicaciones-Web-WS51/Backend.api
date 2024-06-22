using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Commands;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.EventAndTicketing.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.EventAndTicketing.Application.Internal.CommandServices;

public class EventCommandService(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IEventCommandService
{
    public async Task<Event?> Handle(CreateEventCommand command)
    {
        var eventNew = new Event(command);
        try
        {
            await eventRepository.AddAsync(eventNew);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return eventNew;
    }
}