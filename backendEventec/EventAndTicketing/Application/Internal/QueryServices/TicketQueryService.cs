using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Queries;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.EventAndTicketing.Domain.Services;

namespace backendEventec.EventAndTicketing.Application.Internal.QueryServices;

public class TicketQueryService(ITicketRepository ticketRepository) : ITicketQueryService
{
        public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsQuery query)
        {
            return await ticketRepository.FindByAllEventAsync();
        }

        public async Task<Ticket?> Handle(GetTicketByIdQuery query)
        {
            return await ticketRepository.FindByTicketsIdAsync(query.Id);
        }

        public async Task<IEnumerable<Ticket>> Handle(GetTicketsByEventIdQuery query)
        {
            return await ticketRepository.FindByEventsAsync(query.IdEvent);
        }
}
