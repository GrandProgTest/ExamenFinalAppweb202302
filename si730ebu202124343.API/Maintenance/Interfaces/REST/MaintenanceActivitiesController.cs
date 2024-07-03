using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202124343.API.Maintenance.Domain.Model.Queries;
using si730ebu202124343.API.Maintenance.Domain.Services;
using si730ebu202124343.API.Maintenance.Interfaces.REST.Resources;
using si730ebu202124343.API.Maintenance.Interfaces.REST.Transform;

namespace si730ebu202124343.API.Maintenance.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MaintenanceActivitiesController(IMaintenanceActivityCommandService maintenanceActivityCommandService,
    IMaintenanceActivityQueryService maintenanceActivityQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceActivity([FromBody] CreateMaintenanceActivityResource resource)
    {
        var command = CreateMaintenanceActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
        var maintenanceActivity = await maintenanceActivityCommandService.Handle(command);
        if (maintenanceActivity == null)
            return BadRequest();
        var maintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(maintenanceActivity);
        return CreatedAtAction(nameof(GetMaintenanceActivityById), new { maintenanceActivityId = maintenanceActivity.Id }, maintenanceActivityResource);
    }
    
    
    [HttpGet("{maintenanceActivityId:int}")]
    public async Task<IActionResult> GetMaintenanceActivityById(int maintenanceActivityId)
    {
        var query = new GetMaintenanceActivityByIdQuery(maintenanceActivityId);
        var maintenanceActivity = await maintenanceActivityQueryService.Handle(query);
        if (maintenanceActivity == null)
            return NotFound();
        var maintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(maintenanceActivity);
        return Ok(maintenanceActivityResource);
    }
}
