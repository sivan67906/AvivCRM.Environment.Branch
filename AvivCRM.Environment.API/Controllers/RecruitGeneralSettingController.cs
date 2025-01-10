#region

using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.CreateRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.DeleteRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetAllRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetRecruitGeneralSettingById;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.UpdateRecruitGeneralSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruitGeneralSettingController : ControllerBase
{
    private readonly ISender _sender;
    public RecruitGeneralSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-recruitgeneralsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var recruitGeneralSettingList = await _sender.Send(new GetAllRecruitGeneralSettingQuery());
        return Ok(recruitGeneralSettingList);
    }

    [HttpGet("byid-recruitgeneralsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitGeneralSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitgeneralsetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitGeneralSettingRequest recruitGeneralSetting)
    {
        var result = await _sender.Send(new CreateRecruitGeneralSettingCommand(recruitGeneralSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitgeneralsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitGeneralSettingRequest recruitGeneralSetting)
    {
        var result = await _sender.Send(new UpdateRecruitGeneralSettingCommand(recruitGeneralSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitgeneralsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitGeneralSettingCommand(Id));
        return Ok(result);
    }
}