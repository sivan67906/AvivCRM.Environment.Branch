using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.DeleteTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.GetAllTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.GetTimeLogById;
using AvivCRM.Environment.Application.Features.TimeLogs.UpdateTimeLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeLogController : ControllerBase
{

    private readonly ISender _sender;
    public TimeLogController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTimeLogByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTimeLogRequest timeLog)
    {
        var result = await _sender.Send(new CreateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTimeLogRequest timeLog)
    {
        await _sender.Send(new UpdateTimeLogCommand(timeLog));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var timeLogList = await _sender.Send(new GetAllTimeLogQuery());
        return Ok(timeLogList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteTimeLogCommand(Id));
        return NoContent();
    }
}









