using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Commands;

namespace backendEventec.EventAndTicketing.Domain.Services;

public interface ITicketCommandService
{
    Task<Ticket?> Handle(CreateTicketCommand command);
}