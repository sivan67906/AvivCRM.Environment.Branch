#region

using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.CreateRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.DeleteRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Command.UpdateRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Query.GetAllRecruitCustomQuestionSetting;
using AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.Query.GetRecruitCustomQuestionSettingById;
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
        Domain.Responses.ServerResponse recruitCustomQuestionSettingList = await _sender.Send(new GetAllRecruitCustomQuestionSettingQuery());
        return Ok(recruitCustomQuestionSettingList);
    }

    [HttpGet("byid-recruitcustomquestionsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetRecruitCustomQuestionSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitcustomquestionsetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitcustomquestionsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruitCustomQuestionSettingRequest recruitCustomQuestionSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateRecruitCustomQuestionSettingCommand(recruitCustomQuestionSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitcustomquestionsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteRecruitCustomQuestionSettingCommand(Id));
        return Ok(result);
    }
}