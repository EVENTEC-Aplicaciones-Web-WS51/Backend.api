using System.Net.Mime;
using backendEventec.EventAndTicketing.Domain.Model.Queries;
using backendEventec.EventAndTicketing.Domain.Services;
using backendEventec.EventAndTicketing.Interfaces.REST.Resources;
using backendEventec.EventAndTicketing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.EventAndTicketing.Interfaces.REST
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TicketController(ITicketCommandService ticketCommandService, ITicketQueryService ticketQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateTicket([FromBody] CreateTicketResource resource)
        {
            var createTicketCommand = CreateTicketCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await ticketCommandService.Handle(createTicketCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetTicketById), new { id = result.Id },
                TicketResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketById(int id)
        {
            var getTicketByIdQuery = new GetTicketByIdQuery(id);
            var result = await ticketQueryService.Handle(getTicketByIdQuery);
            if (result is null) return NotFound();
            var resource = TicketResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("events/{idEvent}")]
        public async Task<ActionResult> GetTicketsByEventId(int idEvent)
        {
            var getTicketsByEventIdQuery = new GetTicketsByEventIdQuery(idEvent);
            var tickets = await ticketQueryService.Handle(getTicketsByEventIdQuery);
            var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTickets()
        {
            var getAllTicketsQuery = new GetAllTicketsQuery();
            var tickets = await ticketQueryService.Handle(getAllTicketsQuery);
            var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
