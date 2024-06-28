using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Application.Internal.CommandServices;

public class PlaceCommandService(IPlaceRepository placeRepository,IUnitOfWork unitOfWork): IPlaceCommandService
{
    public async Task<Place?> Handle(CreatePlaceCommand command)
    {
        var place = new Place(command);
        try
        {
            await placeRepository.AddAsync(place);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return place;
    }    
}