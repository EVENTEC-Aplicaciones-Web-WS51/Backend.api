using backendEventec.paymethods.Domain.Model.Commands;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.paymethods.Domain.Services;
using backendEventec.Shared.Domain.Repositories;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Application.Internal.CommandServices
{
    public class CardCommandService(ICardRepository cardRepository, IUnitOfWork unitOfWork):
        ICardCommandService
    {
        public async Task<Card?> Handle(CreateCardCommand command)
        {
            var card = new Card(command);
            try
            {
                await cardRepository.AddAsync(card);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return card;
        }
    }
}