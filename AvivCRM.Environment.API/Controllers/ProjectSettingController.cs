#region

using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Application.Features.ProjectSettings.Command.CreateProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.Command.DeleteProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.Command.UpdateProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.Query.GetAllProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.Query.GetProjectSettingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectSettingController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-projectsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse projectSettingList = await _sender.Send(new GetAllProjectSettingQuery());
        return Ok(projectSettingList);
    }

    [HttpGet("byid-projectsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetProjectSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-projectsetting")]
    public async Task<IActionResult> CreateAsync(CreateProjectSettingRequest projectSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateProjectSettingCommand(projectSetting));
        return Ok(result);
    }

    [HttpPut("update-projectsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectSettingRequest projectSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateProjectSettingCommand(projectSetting));
        return Ok(result);
    }

    [HttpDelete("delete-projectsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteProjectSettingCommand(Id));
        return Ok(result);
    }
}