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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetPlanningByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePlanningRequest planning)
    {
        var result = await _sender.Send(new CreatePlanningCommand(planning));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdatePlanningRequest planning)
    {
        await _sender.Send(new UpdatePlanningCommand(planning));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var planningList = await _sender.Send(new GetAllPlanningQuery());
        return Ok(planningList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeletePlanningCommand(Id));
        return NoContent();
    }
}
