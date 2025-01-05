using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Application.Features.ProjectStatuses.CreateProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.DeleteProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.GetAllProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.GetProjectStatusById;
using AvivCRM.Environment.Application.Features.ProjectStatuses.UpdateProjectStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectStatusController : ControllerBase
{

    private readonly ISender _sender;
    public ProjectStatusController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetProjectStatusByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProjectStatusRequest projectStatus)
    {
        var result = await _sender.Send(new CreateProjectStatusCommand(projectStatus));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateProjectStatusRequest projectStatus)
    {
        var result = await _sender.Send(new UpdateProjectStatusCommand(projectStatus));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var projectStatusList = await _sender.Send(new GetAllProjectStatusQuery());
        return Ok(projectStatusList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteProjectStatusCommand(Id));
        return Ok(result);
    }
}
