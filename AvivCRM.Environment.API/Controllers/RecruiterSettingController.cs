using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Application.Features.RecruiterSettings.CreateRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.DeleteRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.GetAllRecruiterSetting;
using AvivCRM.Environment.Application.Features.RecruiterSettings.GetRecruiterSettingById;
using AvivCRM.Environment.Application.Features.RecruiterSettings.UpdateRecruiterSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruiterSettingController : ControllerBase
{

    private readonly ISender _sender;
    public RecruiterSettingController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetRecruiterSettingByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateRecruiterSettingRequest recruiterSetting)
    {
        var result = await _sender.Send(new CreateRecruiterSettingCommand(recruiterSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateRecruiterSettingRequest recruiterSetting)
    {
        var result = await _sender.Send(new UpdateRecruiterSettingCommand(recruiterSetting));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var recruiterSettingList = await _sender.Send(new GetAllRecruiterSettingQuery());
        return Ok(recruiterSettingList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteRecruiterSettingCommand(Id));
        return Ok(result);
    }
}









