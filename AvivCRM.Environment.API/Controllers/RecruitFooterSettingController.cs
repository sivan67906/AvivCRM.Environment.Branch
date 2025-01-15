#region

using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.CreateRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.DeleteRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.UpdateRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.Query.GetAllRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.Query.GetRecruitFooterSettingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruitFooterSettingController : ControllerBase
{
    private readonly ISender _sender;

    public RecruitFooterSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-recruitfootersetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse recruitFooterSettingList = await _sender.Send(new GetAllRecruitFooterSettingQuery());
        return Ok(recruitFooterSettingList);
    }

    [HttpGet("byid-recruitfootersetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetRecruitFooterSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitfootersetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitFooterSettingRequest recruitFooterSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateRecruitFooterSettingCommand(recruitFooterSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitfootersetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitFooterSettingRequest recruitFooterSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateRecruitFooterSettingCommand(recruitFooterSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitfootersetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteRecruitFooterSettingCommand(Id));
        return Ok(result);
    }
}