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

    [HttpGet("all-timesheet")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse timesheetList = await _sender.Send(new GetAllTimesheetQuery());
        return Ok(timesheetList);
    }

    [HttpGet("byid-timesheet")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTimesheetByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-timesheet")]
    public async Task<IActionResult> CreateAsync(CreateTimesheetRequest timesheet)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpPut("update-timesheet")]
    public async Task<IActionResult> UpdateAsync(UpdateTimesheetRequest timesheet)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpDelete("delete-timesheet")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTimesheetCommand(Id));
        return Ok(result);
    }
}