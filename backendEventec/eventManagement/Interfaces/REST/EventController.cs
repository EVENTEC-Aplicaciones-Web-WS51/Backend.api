using System.Net.Mime;
using backendEventec.eventManagement.Domain.Services;
using backendEventec.eventManagement.Interfaces.REST.Resources;
using backendEventec.eventManagement.Interfaces.REST.Transform;
using BDEventecFinal.eventManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.eventManagement.Interfaces.REST;

[ApiController]
[Route("/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class EventController(IEventCommandService eventCommandService, IEventQueryService eventQueryService): ControllerBase
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

    [HttpGet]
    public async Task<ActionResult> GetAllEvents()
    {
        var getAllEventsQuery = new GetAllEventQuery();
        var events = await eventQueryService.Handle(getAllEventsQuery);
        var resources = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("Name/{name}")]
    public async Task<ActionResult> GetEventByName(string name)
    {
        var getEventByNameQuery = new GetEventByNameQuery(name);
        var result = await eventQueryService.Handle(getEventByNameQuery);
        if (result is null) return NotFound();
        var resource = EventResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}