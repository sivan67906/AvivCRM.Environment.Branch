using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.CreateTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.DeleteTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.GetAllTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.GetTimeZoneStandardById;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.UpdateTimeZoneStandard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeZoneStandardController : ControllerBase
{

    private readonly ISender _sender;
    public TimeZoneStandardController(ISender sender) => _sender = sender;

    [HttpGet("all-timezonestandard")]
    public async Task<IActionResult> GetAllAsync()
    {
        var timeZoneStandardList = await _sender.Send(new GetAllTimeZoneStandardQuery());
        return Ok(timeZoneStandardList);
    }

    [HttpGet("byid-timezonestandard")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTimeZoneStandardByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-timezonestandard")]
    public async Task<IActionResult> CreateAsync(CreateTimeZoneStandardRequest timeZoneStandard)
    {
        var result = await _sender.Send(new CreateTimeZoneStandardCommand(timeZoneStandard));
        return Ok(result);
    }

    [HttpPut("update-timezonestandard")]
    public async Task<IActionResult> UpdateAsync(UpdateTimeZoneStandardRequest timeZoneStandard)
    {
        var result = await _sender.Send(new UpdateTimeZoneStandardCommand(timeZoneStandard));
        return Ok(result);
    }

    [HttpDelete("delete-timezonestandard")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTimeZoneStandardCommand(Id));
        return Ok(result);
    }
}






















