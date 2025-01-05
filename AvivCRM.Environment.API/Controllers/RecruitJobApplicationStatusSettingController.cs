using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.CreateRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.DeleteRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetAllRecruitJobApplicationStatusSetting;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetRecruitJobApplicationStatusSettingById;
using AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.UpdateRecruitJobApplicationStatusSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitJobApplicationStatusSettingController : ControllerBase
{

    private readonly ISender _sender;
    public RecruitJobApplicationStatusSettingController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitJobApplicationStatusSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        var result = await _sender.Send(new CreateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRecruitJobApplicationStatusSettingRequest recruitJobApplicationStatusSetting)
    {
        var result = await _sender.Send(new UpdateRecruitJobApplicationStatusSettingCommand(recruitJobApplicationStatusSetting));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var recruitJobApplicationStatusSettingList = await _sender.Send(new GetAllRecruitJobApplicationStatusSettingQuery());
        return Ok(recruitJobApplicationStatusSettingList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitJobApplicationStatusSettingCommand(Id));
        return Ok(result);
    }
}