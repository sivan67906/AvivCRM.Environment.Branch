#region

using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Application.Features.Plannings.Command.CreatePlanning;
using AvivCRM.Environment.Application.Features.Plannings.Command.DeletePlanning;
using AvivCRM.Environment.Application.Features.Plannings.Command.UpdatePlanning;
using AvivCRM.Environment.Application.Features.Plannings.Query.GetAllPlanning;
using AvivCRM.Environment.Application.Features.Plannings.Query.GetPlanningById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlanningController : ControllerBase
{
    private readonly ISender _sender;

    public PlanningController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-planning")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse planningList = await _sender.Send(new GetAllPlanningQuery());
        return Ok(planningList);
    }

    [HttpGet("byid-planning")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetPlanningByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-planning")]
    public async Task<IActionResult> CreateAsync(CreatePlanningRequest planning)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreatePlanningCommand(planning));
        return Ok(result);
    }

    [HttpPut("update-planning")]
    public async Task<IActionResult> UpdateAsync(UpdatePlanningRequest planning)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdatePlanningCommand(planning));
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeletePlanningCommand(Id));
        return Ok(result);
    }
}