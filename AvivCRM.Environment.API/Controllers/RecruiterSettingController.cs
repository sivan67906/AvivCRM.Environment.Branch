#region

using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Application.Features.RecruiterSettings.Command.CreateRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.Command.DeleteRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.Command.UpdateRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.Query.GetAllRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.Query.GetRecruiterSettingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruiterSettingController : ControllerBase
{
    private readonly ISender _sender;

    public RecruiterSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-recruitersetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse recruiterSettingList = await _sender.Send(new GetAllRecruiterSettingQuery());
        return Ok(recruiterSettingList);
    }

    [HttpGet("byid-recruitersetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetRecruiterSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-recruitersetting")]
    public async Task<IActionResult> CreateAsync(CreateRecruiterSettingRequest recruiterSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateRecruiterSettingCommand(recruiterSetting));
        return Ok(result);
    }

    [HttpPut("update-recruitersetting")]
    public async Task<IActionResult> UpdateAsync(UpdateRecruiterSettingRequest recruiterSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateRecruiterSettingCommand(recruiterSetting));
        return Ok(result);
    }

    [HttpDelete("delete-recruitersetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteRecruiterSettingCommand(Id));
        return Ok(result);
    }
}