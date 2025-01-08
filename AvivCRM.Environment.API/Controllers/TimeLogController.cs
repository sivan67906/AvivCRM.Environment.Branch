#region

using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.DeleteTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.GetAllTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.GetTimeLogById;
using AvivCRM.Environment.Application.Features.TimeLogs.UpdateTimeLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TimeLogController : ControllerBase
{
    private readonly ISender _sender;

    public TimeLogController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-timelog")]
    public async Task<IActionResult> GetAllAsync()
    {
        var timeLogList = await _sender.Send(new GetAllTimeLogQuery());
        return Ok(timeLogList);
    }

    [HttpGet("byid-timelog")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTimeLogByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-timelog")]
    public async Task<IActionResult> CreateAsync(CreateTimeLogRequest timeLog)
    {
        var result = await _sender.Send(new CreateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpPut("update-timelog")]
    public async Task<IActionResult> UpdateAsync(UpdateTimeLogRequest timeLog)
    {
        var result = await _sender.Send(new UpdateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpDelete("delete-timelog")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTimeLogCommand(Id));
        return Ok(result);
    }
}