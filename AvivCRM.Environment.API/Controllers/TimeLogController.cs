#region

using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.Features.TimeLogs.Command.CreateTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.Command.DeleteTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.Command.UpdateTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.Query.GetAllTimeLog;
using AvivCRM.Environment.Application.Features.TimeLogs.Query.GetTimeLogById;
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
        Domain.Responses.ServerResponse timeLogList = await _sender.Send(new GetAllTimeLogQuery());
        return Ok(timeLogList);
    }

    [HttpGet("byid-timelog")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTimeLogByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-timelog")]
    public async Task<IActionResult> CreateAsync(CreateTimeLogRequest timeLog)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpPut("update-timelog")]
    public async Task<IActionResult> UpdateAsync(UpdateTimeLogRequest timeLog)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTimeLogCommand(timeLog));
        return Ok(result);
    }

    [HttpDelete("delete-timelog")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTimeLogCommand(Id));
        return Ok(result);
    }
}