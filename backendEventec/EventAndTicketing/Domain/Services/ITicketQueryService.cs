using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Queries;

namespace backendEventec.EventAndTicketing.Domain.Services;

public interface ITicketQueryService
{
    Task<IEnumerable<Ticket>> Handle(GetAllTicketsQuery query);
    Task<Ticket?> Handle(GetTicketByIdQuery query);
    Task<IEnumerable<Ticket>> Handle(GetTicketsByEventIdQuery query);
}