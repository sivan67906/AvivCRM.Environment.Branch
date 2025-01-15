#region

using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.CreateRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.DeleteRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.UpdateRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Query.GetAllRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Query.GetRecruitJobApplicationStatusSettingById;
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

    [HttpGet("all-recruitjobapplicationstatussetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse recruitJobApplicationStatusSettingList =
            await _sender.Send(new GetAllRecruitJobApplicationStatusSettingQuery());
        return Ok(recruitJobApplicationStatusSettingList);
    }

    [HttpGet("byid-recruitjobapplicationstatussetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetRecruitJobApplicationStatusSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitjobapplicationstatussetting")]
    public async Task<IActionResult> CreateAsync(
        CreateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        Domain.Responses.ServerResponse result =
            await _sender.Send(new CreateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitjobapplicationstatussetting")]
    public async Task<IActionResult> UpdateAsync(
        UpdateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        Domain.Responses.ServerResponse result =
            await _sender.Send(new UpdateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitjobapplicationstatussetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteRecruitJobApplicationStatusSettingCommand(Id));
        return Ok(result);
    }
}