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
    public class EventController(IEventCommandService eventCommandService, IEventQueryService eventQueryService) : ControllerBase
    {
        
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] CreateEventResource resource)
        {
            var createEventCommand = CreateEventCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await eventCommandService.Handle(createEventCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetEventById), new { id = result.Id },
                EventResourceFromEntityAssembler.ToResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEventById(int id)
        {
            var getEventByIdQuery = new GetEventByIdQuery(id);
            var result = await eventQueryService.Handle(getEventByIdQuery);
            if (result is null) return NotFound();
            var resource = EventResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("headquarters/{idHeadquarters}")]
        public async Task<ActionResult> GetEventByHeadquarters(int idHeadquarters)
        {
            var getEventByHeadquartersQuery = new GetEventByHeadquarters(idHeadquarters);
            var events = await eventQueryService.Handle(getEventByHeadquartersQuery);
            var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("organizers/{idOrganizer}")]
        public async Task<ActionResult> GetEventByOrganizerId(int idOrganizer)
        {
            var getEventByOrganizerIdQuery = new GetEventByOrganizerIdQuery(idOrganizer);
            var events = await eventQueryService.Handle(getEventByOrganizerIdQuery);
            var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEvents()
        {
            var getAllEventsQuery = new GetAllEventQuery();
            var events = await eventQueryService.Handle(getAllEventsQuery);
            var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
