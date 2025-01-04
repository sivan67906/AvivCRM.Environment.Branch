using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.CreateRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.DeleteRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetAllRecruitGeneralSetting;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.GetRecruitGeneralSettingById;
using AvivCRM.Environment.Application.Features.RecruitGeneralSettings.UpdateRecruitGeneralSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitGeneralSettingController : ControllerBase
{

    private readonly ISender _sender;
    public RecruitGeneralSettingController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitGeneralSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateRecruitGeneralSettingRequest recruitGeneralSetting)
    {
        var result = await _sender.Send(new CreateRecruitGeneralSettingCommand(recruitGeneralSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRecruitGeneralSettingRequest recruitGeneralSetting)
    {
        await _sender.Send(new UpdateRecruitGeneralSettingCommand(recruitGeneralSetting));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var recruitGeneralSettingList = await _sender.Send(new GetAllRecruitGeneralSettingQuery());
        return Ok(recruitGeneralSettingList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteRecruitGeneralSettingCommand(Id));
        return NoContent();
    }
}