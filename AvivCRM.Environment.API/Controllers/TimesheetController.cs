using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.DeleteTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.GetAllTimesheet;
using AvivCRM.Environment.Application.Features.Timesheets.GetTimesheetById;
using AvivCRM.Environment.Application.Features.Timesheets.UpdateTimesheet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimesheetController : ControllerBase
{

    private readonly ISender _sender;
    public TimesheetController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTimesheetByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTimesheetRequest timesheet)
    {
        var result = await _sender.Send(new CreateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateTimesheetRequest timesheet)
    {
        var result = await _sender.Send(new UpdateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var timesheetList = await _sender.Send(new GetAllTimesheetQuery());
        return Ok(timesheetList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTimesheetCommand(Id));
        return Ok(result);
    }
}