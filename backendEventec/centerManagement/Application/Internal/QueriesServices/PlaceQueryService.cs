using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;


namespace backendEventec.CenterManagement.Application.Internal.QueriesServices;

public class PlaceQueryService(IPlaceRepository placeRepository): IPlaceQueryService
{
    public async Task<IEnumerable<Place>> Handle(GetAllPlacesQuery query)
    {
        return await placeRepository.FindAllAsync();
    }

    public async Task<Place?> Handle(GetPlaceByIdQuery query)
    {
        return await placeRepository.FindByIdAsync(query.Id);
    }
}