using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.CreateRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.DeleteRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetAllRecruitFooterSetting;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetRecruitFooterSettingById;
using AvivCRM.Environment.Application.Features.RecruitFooterSettings.UpdateRecruitFooterSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitFooterSettingController : ControllerBase
{

    private readonly ISender _sender;
    public RecruitFooterSettingController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitFooterSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateRecruitFooterSettingRequest recruitFooterSetting)
    {
        var result = await _sender.Send(new CreateRecruitFooterSettingCommand(recruitFooterSetting));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitFooterSettingRequest recruitFooterSetting)
    {
        var result = await _sender.Send(new UpdateRecruitFooterSettingCommand(recruitFooterSetting));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var recruitFooterSettingList = await _sender.Send(new GetAllRecruitFooterSettingQuery());
        return Ok(recruitFooterSettingList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitFooterSettingCommand(Id));
        return Ok(result);
    }
}