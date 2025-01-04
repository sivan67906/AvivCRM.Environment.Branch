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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitFooterSettingByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateRecruitFooterSettingRequest recruitFooterSetting)
    {
        var result = await _sender.Send(new CreateRecruitFooterSettingCommand(recruitFooterSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRecruitFooterSettingRequest recruitFooterSetting)
    {
        await _sender.Send(new UpdateRecruitFooterSettingCommand(recruitFooterSetting));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var recruitFooterSettingList = await _sender.Send(new GetAllRecruitFooterSettingQuery());
        return Ok(recruitFooterSettingList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteRecruitFooterSettingCommand(Id));
        return NoContent();
    }
}









