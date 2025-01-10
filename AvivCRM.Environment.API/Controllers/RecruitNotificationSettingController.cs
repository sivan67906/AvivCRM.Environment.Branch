#region

using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.CreateRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.DeleteRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetAllRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.GetRecruitNotificationSettingById;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.UpdateRecruitNotificationSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruitNotificationSettingController : ControllerBase
{
    private readonly ISender _sender;

    public RecruitNotificationSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-recruitnotificationsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var recruitNotificationSettingList = await _sender.Send(new GetAllRecruitNotificationSettingQuery());
        return Ok(recruitNotificationSettingList);
    }

    [HttpGet("byid-recruitnotificationsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitNotificationSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitnotificationsetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitNotificationSettingRequest recruitNotificationSetting)
    {
        var result = await _sender.Send(new CreateRecruitNotificationSettingCommand(recruitNotificationSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitnotificationsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitNotificationSettingRequest recruitNotificationSetting)
    {
        var result = await _sender.Send(new UpdateRecruitNotificationSettingCommand(recruitNotificationSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitnotificationsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitNotificationSettingCommand(Id));
        return Ok(result);
    }
}