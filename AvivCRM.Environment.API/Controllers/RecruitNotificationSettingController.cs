#region

using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.CreateRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.DeleteRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Command.UpdateRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Query.GetAllRecruitNotificationSetting;
using AvivCRM.Environment.Application.Features.RecruitNotificationSettings.Query.GetRecruitNotificationSettingById;
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
        Domain.Responses.ServerResponse recruitNotificationSettingList = await _sender.Send(new GetAllRecruitNotificationSettingQuery());
        return Ok(recruitNotificationSettingList);
    }

    [HttpGet("byid-recruitnotificationsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetRecruitNotificationSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitnotificationsetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitNotificationSettingRequest recruitNotificationSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateRecruitNotificationSettingCommand(recruitNotificationSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitnotificationsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitNotificationSettingRequest recruitNotificationSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateRecruitNotificationSettingCommand(recruitNotificationSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitnotificationsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteRecruitNotificationSettingCommand(Id));
        return Ok(result);
    }
}