#region

using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.CreateRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.DeleteRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetAllRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.GetRecruitCustomQuestionSettingById;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.UpdateRecruitCustomQuestionSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruitCustomQuestionSettingController : ControllerBase
{
    private readonly ISender _sender;

    public RecruitCustomQuestionSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-recruitcustomquestionsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var recruitCustomQuestionSettingList = await _sender.Send(new GetAllRecruitCustomQuestionSettingQuery());
        return Ok(recruitCustomQuestionSettingList);
    }

    [HttpGet("byid-recruitcustomquestionsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetRecruitCustomQuestionSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitcustomquestionsetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        var result = await _sender.Send(new CreateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitcustomquestionsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        var result = await _sender.Send(new UpdateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitcustomquestionsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruitCustomQuestionSettingCommand(Id));
        return Ok(result);
    }
}