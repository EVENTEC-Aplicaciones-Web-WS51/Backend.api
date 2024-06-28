using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;


namespace backendEventec.CenterManagement.Application.Internal.QueriesServices;

public class HeadquartersQueryService(IHeadquartersRepository headquartersRepository): IHeadquartersQueryService
{
    public async Task<Headquarters?> Handle(GetHeadquartersByIdQuery query)
    {
        return await headquartersRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Headquarters>> Handle(GetHeadquartersByPlaceIdQuery query)
    {
        return await headquartersRepository.FindByPlaceIdAsync(query.IdPlace);
    }

    public async Task<IEnumerable<Headquarters>> Handle(GetAllHeadquartersQuery query)
    {
        return await headquartersRepository.FindAllAsync();
    }
}