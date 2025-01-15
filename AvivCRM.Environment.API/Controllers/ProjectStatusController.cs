#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Command.CreateProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Command.DeleteProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Command.UpdateProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Command.UpdateProjectStatusDefault;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Query.GetAllProjectStatus;
using AvivCRM.Environment.Application.Features.ProjectStatuses.Query.GetProjectStatusById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectStatusController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectStatusController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-projectstatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse projectStatusList = await _sender.Send(new GetAllProjectStatusQuery());
        return Ok(projectStatusList);
    }

    [HttpGet("byid-projectstatus")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetProjectStatusByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-projectstatus")]
    public async Task<IActionResult> CreateAsync(CreateProjectStatusRequest projectStatus)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateProjectStatusCommand(projectStatus));
        return Ok(result);
    }

    [HttpPut("update-projectstatus")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectStatusRequest projectStatus)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateProjectStatusCommand(projectStatus));
        return Ok(result);
    }

    [HttpPut("update-projectstatusdefaultstatus")]
    public async Task<IActionResult> UpdateDefaultStatus(UpdateProjectStatusDefaultRequest projectStatus)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateProjectStatusDefaultCommand(projectStatus));
        return Ok(result);
    }

    [HttpDelete("delete-projectstatus")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteProjectStatusCommand(Id));
        return Ok(result);
    }
}