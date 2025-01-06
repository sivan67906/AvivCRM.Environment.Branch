using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Application.Features.ProjectSettings.CreateProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.DeleteProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.GetAllProjectSetting;
using AvivCRM.Environment.Application.Features.ProjectSettings.GetProjectSettingById;
using AvivCRM.Environment.Application.Features.ProjectSettings.UpdateProjectSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectSettingController : ControllerBase
{

    private readonly ISender _sender;
    public ProjectSettingController(ISender sender) => _sender = sender;

    [HttpGet("all-projectsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var projectSettingList = await _sender.Send(new GetAllProjectSettingQuery());
        return Ok(projectSettingList);
    }

    [HttpGet("byid-projectsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetProjectSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-projectsetting")]
    public async Task<IActionResult> CreateAsync(CreateProjectSettingRequest projectSetting)
    {
        var result = await _sender.Send(new CreateProjectSettingCommand(projectSetting));
        return Ok(result);
    }

    [HttpPut("update-projectsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateProjectSettingRequest projectSetting)
    {
        var result = await _sender.Send(new UpdateProjectSettingCommand(projectSetting));
        return Ok(result);
    }

    [HttpDelete("delete-projectsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteProjectSettingCommand(Id));
        return Ok(result);
    }
}