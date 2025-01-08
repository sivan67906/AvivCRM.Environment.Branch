#region

using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    CreateRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    DeleteRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    GetAllRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    GetRecruitJobApplicationStatusSettingById;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    UpdateRecruitJobApplicationStatusSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruitJobApplicationStatusSettingController : ControllerBase
{
    private readonly ISender _sender;

    public RecruitJobApplicationStatusSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitJobApplicationStatusSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(
        CreateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        var result =
            await _sender.Send(new CreateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(
        UpdateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        var result =
            await _sender.Send(new UpdateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var recruitJobApplicationStatusSettingList =
            await _sender.Send(new GetAllRecruitJobApplicationStatusSettingQuery());
        return Ok(recruitJobApplicationStatusSettingList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitJobApplicationStatusSettingCommand(Id));
        return Ok(result);
    }
}