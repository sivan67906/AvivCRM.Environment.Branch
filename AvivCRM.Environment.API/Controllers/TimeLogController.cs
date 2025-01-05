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

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTimeLogByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTimeLogRequest timeLog)
    {
        var result = await _sender.Send(new CreateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateTimeLogRequest timeLog)
    {
        var result = await _sender.Send(new UpdateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var timeLogList = await _sender.Send(new GetAllTimeLogQuery());
        return Ok(timeLogList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTimeLogCommand(Id));
        return Ok(result);
    }
}