using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Application.Internal.CommandServices;

public class OrganizerCommandService(IOrganizerRepository organizerRepository,IUnitOfWork unitOfWork): IOrganizerCommandService
{
    public async Task<Organizer?> Handle(CreateOrganizerCommand command)
    {
        var organizer = new Organizer(command);
        try
        {
            await organizerRepository.AddAsync(organizer);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return organizer;
    } 
}