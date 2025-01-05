using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Application.Features.Plannings.CreatePlanning;
using AvivCRM.Environment.Application.Features.Plannings.DeletePlanning;
using AvivCRM.Environment.Application.Features.Plannings.GetAllPlanning;
using AvivCRM.Environment.Application.Features.Plannings.GetPlanningById;
using AvivCRM.Environment.Application.Features.Plannings.UpdatePlanning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlanningController : ControllerBase
{
    private readonly ISender _sender;
    public PlanningController(ISender sender) => _sender = sender;

    [HttpGet("all-planning")]
    public async Task<IActionResult> GetAllAsync()
    {
        var planningList = await _sender.Send(new GetAllPlanningQuery());
        return Ok(planningList);
    }

    [HttpGet("byid-planning")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetPlanningByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-planning")]
    public async Task<IActionResult> CreateAsync(CreatePlanningRequest planning)
    {
        var result = await _sender.Send(new CreatePlanningCommand(planning));
        return Ok(result);
    }

    [HttpPut("update-planning")]
    public async Task<IActionResult> UpdateAsync(UpdatePlanningRequest planning)
    {
        await _sender.Send(new UpdatePlanningCommand(planning));
        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        await _sender.Send(new DeletePlanningCommand(Id));
        return NoContent();
    }
}
