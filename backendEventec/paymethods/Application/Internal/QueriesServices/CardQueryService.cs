using backendEventec.paymethods.Domain.Model.Queries;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.paymethods.Domain.Services;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Application.Internal.QueriesServices
{
    public class CardQueryService(ICardRepository cardRepository) : ICardQueryService
    {
        public async Task<IEnumerable<Card>> Handle(GetAllCardQuery query)
        {
            return await cardRepository.FindAllAsync();
        }

        public async Task<Card?> Handle(GetCardByIdQuery query)
        {
            return await cardRepository.FindByIdAsync(query.Id);
        }

        public async Task<IEnumerable<Card>> Handle(GetCardByWalletIdQuery query)
        {
            return await cardRepository.FindByWalletIdAsync(query.IdWallet);
        }
    }
}

    