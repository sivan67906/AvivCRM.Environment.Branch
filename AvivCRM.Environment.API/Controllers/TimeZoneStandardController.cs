using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.Command.CreateTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.Command.DeleteTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.Command.UpdateTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.Query.GetAllTimeZoneStandard;
using AvivCRM.Environment.Application.Features.TimeZoneStandards.Query.GetTimeZoneStandardById;
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
        Domain.Responses.ServerResponse timeZoneStandardList = await _sender.Send(new GetAllTimeZoneStandardQuery());
        return Ok(timeZoneStandardList);
    }

    [HttpGet("byid-timezonestandard")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTimeZoneStandardByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-timezonestandard")]
    public async Task<IActionResult> CreateAsync(CreateTimeZoneStandardRequest timeZoneStandard)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTimeZoneStandardCommand(timeZoneStandard));
        return Ok(result);
    }

    [HttpPut("update-timezonestandard")]
    public async Task<IActionResult> UpdateAsync(UpdateTimeZoneStandardRequest timeZoneStandard)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTimeZoneStandardCommand(timeZoneStandard));
        return Ok(result);
    }

    [HttpDelete("delete-timezonestandard")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTimeZoneStandardCommand(Id));
        return Ok(result);
    }
}






















