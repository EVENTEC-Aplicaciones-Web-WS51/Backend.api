using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Commands;

namespace backendEventec.paymethods.Domain.Services
{
    public interface ICardCommandService
    {
        Task<Card?> Handle(CreateCardCommand command);
    }
}