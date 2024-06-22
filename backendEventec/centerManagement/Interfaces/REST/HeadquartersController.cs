using System.Net.Mime;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.CenterManagement.Interfaces.REST.Resources;
using backendEventec.CenterManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.CenterManagement.Interfaces.REST;


[ApiController]
[Route("/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class HeadquartersController(IHeadquartersCommandService headquartersCommandService, IHeadquartersQueryService headquartersQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateHeadquarters([FromBody] CreateHeadquartersResource resource)
    {
        var createHeadquartersCommand = CreateHeadquartersCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await headquartersCommandService.Handle(createHeadquartersCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetHeadquartersById), new { id = result.Id },
            HeadquartersResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetHeadquartersById(int id)
    {
        var getHeadquartersByIdQuery = new GetHeadquartersByIdQuery(id);
        var result = await headquartersQueryService.Handle(getHeadquartersByIdQuery);
        if (result is null) return NotFound();
        var resource = HeadquartersResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllHeadquarters()
    {
        var getAllHeadquartersQuery = new GetAllHeadquartersQuery();
        var headquarters = await headquartersQueryService.Handle(getAllHeadquartersQuery);
        var resources = headquarters.Select(HeadquartersResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("place/{idPlace}")]
    public async Task<ActionResult> GetHeadquartersByPlaceId(int idPlace)
    {
        var getHeadquartersByPlaceIdQuery = new GetHeadquartersByPlaceIdQuery(idPlace);
        var headquarters = await headquartersQueryService.Handle(getHeadquartersByPlaceIdQuery);
        var resources = headquarters.Select(HeadquartersResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
