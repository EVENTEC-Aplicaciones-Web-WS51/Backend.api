using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Application.Internal.CommandServices;

public class HeadquartersCommandService(IHeadquartersRepository headquartersRepository,IUnitOfWork unitOfWork): IHeadquartersCommandService
{
    public async Task<Headquarters?> Handle(CreateHeadquartersCommand command)
    {
        var headquarters = new Headquarters(command);
        try
        {
            await headquartersRepository.AddAsync(headquarters);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return headquarters;
    }    
}