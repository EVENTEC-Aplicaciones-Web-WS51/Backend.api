using backendEventec.eventManagement.Domain.Repositories;
using backendEventec.eventManagement.Domain.Services;
using backendEventec.Shared.Domain.Repositories;
using BDEventecFinal.eventManagement.Domain.Model.Aggregates;
using BDEventecFinal.eventManagement.Domain.Model.Commands;

namespace backendEventec.eventManagement.Application.Internal.CommandServices;

public class EventCommandService(IEventRepository eventRepository,IUnitOfWork unitOfWork): IEventCommandService
{
    public async Task<Event?> Handle(CreateEventCommand command)
    {
        var _event = new Event(command);
        try
        {
            await eventRepository.AddAsync(_event);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return _event;
    }
}