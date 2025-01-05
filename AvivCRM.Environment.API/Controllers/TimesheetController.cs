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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTimesheetByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTimesheetRequest timesheet)
    {
        var result = await _sender.Send(new CreateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTimesheetRequest timesheet)
    {
        var result = await _sender.Send(new UpdateTimesheetCommand(timesheet));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var timesheetList = await _sender.Send(new GetAllTimesheetQuery());
        return Ok(timesheetList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteTimesheetCommand(Id));
        return Ok(result);
    }
}