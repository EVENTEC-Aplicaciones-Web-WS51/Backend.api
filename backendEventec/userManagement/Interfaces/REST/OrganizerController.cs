using System.Net.Mime;
using backendEventec.UserManagement.Domain.Model.Queries;
using backendEventec.UserManagement.Domain.Services;
using backendEventec.UserManagement.Interfaces.REST.Resources;
using backendEventec.UserManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.UserManagement.Interfaces.REST;

[ApiController]
[Route("/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class OrganizerController(IOrganizerCommandService organizerCommandService, IOrganizerQueryService organizerQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateOrganizer([FromBody] CreateOrganizerResource resource)
    {
        var createOrganizerCommand = CreateOrganizerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await organizerCommandService.Handle(createOrganizerCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrganizerById), new { id = result.Id },
            OrganizerResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOrganizerById(int id)
    {
        var getOrganizerByIdQuery = new GetOrganizerByIdQuery(id);
        var result = await organizerQueryService.Handle(getOrganizerByIdQuery);
        if (result is null) return NotFound();
        var resource = OrganizerResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("users/{userId}")]
    public async Task<ActionResult> GetOrganizersByUserId(int userId)
    {
        var getOrganizersByUserIdQuery = new GetOrganizersByUserIdQuery(userId);
        var organizers = await organizerQueryService.Handle(getOrganizersByUserIdQuery);
        var resources = organizers.Select(OrganizerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("companies/{companyId}")]
    public async Task<ActionResult> GetOrganizersByCompanyId(int companyId)
    {
        var getOrganizersByCompanyIdQuery = new GetOrganizersByCompanyIdQuery(companyId);
        var organizers = await organizerQueryService.Handle(getOrganizersByCompanyIdQuery);
        var resources = organizers.Select(OrganizerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllOrganizers()
    {
        var getAllOrganizersQuery = new GetAllOrganizersQuery();
        var organizers = await organizerQueryService.Handle(getAllOrganizersQuery);
        var resources = organizers.Select(OrganizerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}