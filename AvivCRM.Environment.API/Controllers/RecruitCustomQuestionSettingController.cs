using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.CreateRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.DeleteRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetAllRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetRecruitCustomQuestionSettingById;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.UpdateRecruitCustomQuestionSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitCustomQuestionSettingController : ControllerBase
{

    private readonly ISender _sender;
    public RecruitCustomQuestionSettingController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitCustomQuestionSettingByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        var result = await _sender.Send(new CreateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        var result = await _sender.Send(new UpdateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var recruitCustomQuestionSettingList = await _sender.Send(new GetAllRecruitCustomQuestionSettingQuery());
        return Ok(recruitCustomQuestionSettingList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitCustomQuestionSettingCommand(Id));
        return Ok(result);
    }
}









