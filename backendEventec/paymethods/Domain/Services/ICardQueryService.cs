using backendEventec.paymethods.Domain.Model.Queries;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Domain.Services
{
    public interface ICardQueryService
    {
        Task<IEnumerable<Card>> Handle(GetAllCardQuery query);
        Task<Card?> Handle(GetCardByIdQuery query);
        Task<IEnumerable<Card>> Handle(GetCardByWalletIdQuery query);
    }
}