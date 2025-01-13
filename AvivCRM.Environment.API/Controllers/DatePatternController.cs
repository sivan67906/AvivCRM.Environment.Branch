using AvivCRM.Environment.Application.DTOs.DatePatterns;
using AvivCRM.Environment.Application.Features.DatePatterns.CreateDatePattern;
using AvivCRM.Environment.Application.Features.DatePatterns.DeleteDatePattern;
using AvivCRM.Environment.Application.Features.DatePatterns.GetAllDatePattern;
using AvivCRM.Environment.Application.Features.DatePatterns.GetDatePatternById;
using AvivCRM.Environment.Application.Features.DatePatterns.UpdateDatePattern;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DatePatternController : ControllerBase
{

    private readonly ISender _sender;
    public DatePatternController(ISender sender) => _sender = sender;

    [HttpGet("all-datepattern")]
    public async Task<IActionResult> GetAllAsync()
    {
        var datePatternList = await _sender.Send(new GetAllDatePatternQuery());
        return Ok(datePatternList);
    }

    [HttpGet("byid-datepattern")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetDatePatternByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-datepattern")]
    public async Task<IActionResult> CreateAsync(CreateDatePatternRequest datePattern)
    {
        var result = await _sender.Send(new CreateDatePatternCommand(datePattern));
        return Ok(result);
    }

    [HttpPut("update-datepattern")]
    public async Task<IActionResult> UpdateAsync(UpdateDatePatternRequest datePattern)
    {
        var result = await _sender.Send(new UpdateDatePatternCommand(datePattern));
        return Ok(result);
    }

    [HttpDelete("delete-datepattern")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteDatePatternCommand(Id));
        return Ok(result);
    }
}






















