using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Commands;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.EventAndTicketing.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.EventAndTicketing.Application.Internal.CommandServices;

public class TicketCommandService(ITicketRepository ticketRepository, IUnitOfWork unitOfWork) : ITicketCommandService
{
    public async Task<Ticket?> Handle(CreateTicketCommand command)
    {
        var ticket = new Ticket(command);
        try
        {
            await ticketRepository.AddAsync(ticket);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return ticket;
    }
}