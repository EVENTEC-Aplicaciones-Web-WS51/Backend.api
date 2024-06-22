using backendEventec.paymethods.Domain.Model.Commands;
using Paymethods.paymethods.Domain.Model.Aggregates;

namespace backendEventec.paymethods.Domain.Services
{
    public interface ICardCommandService
    {
        Task<Card?> Handle(CreateCardCommand command);
    }
}