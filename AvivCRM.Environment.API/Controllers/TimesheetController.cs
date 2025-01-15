#region

using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Application.Features.Timesheets.Command.CreateTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.Command.DeleteTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.Command.UpdateTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.Query.GetAllTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.Query.GetTimesheetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TimesheetController : ControllerBase
{
    private readonly ISender _sender;

    public TimesheetController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTimesheetByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTimesheetRequest timesheet)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateTimesheetRequest timesheet)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse timesheetList = await _sender.Send(new GetAllTimesheetQuery());
        return Ok(timesheetList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTimesheetCommand(Id));
        return Ok(result);
    }
}