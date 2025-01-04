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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetProjectSettingByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProjectSettingRequest projectSetting)
    {
        var result = await _sender.Send(new CreateProjectSettingCommand(projectSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateProjectSettingRequest projectSetting)
    {
        await _sender.Send(new UpdateProjectSettingCommand(projectSetting));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var projectSettingList = await _sender.Send(new GetAllProjectSettingQuery());
        return Ok(projectSettingList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteProjectSettingCommand(Id));
        return NoContent();
    }
}
