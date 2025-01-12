using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Application.Features.ToggleValues.CreateToggleValue;
using AvivCRM.Environment.Application.Features.ToggleValues.DeleteToggleValue;
using AvivCRM.Environment.Application.Features.ToggleValues.GetAllToggleValue;
using AvivCRM.Environment.Application.Features.ToggleValues.GetToggleValueById;
using AvivCRM.Environment.Application.Features.ToggleValues.UpdateToggleValue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToggleValueController : ControllerBase
{

    private readonly ISender _sender;
    public ToggleValueController(ISender sender) => _sender = sender;

    [HttpGet("all-togglevalue")]
    public async Task<IActionResult> GetAllAsync()
    {
        var toggleValueList = await _sender.Send(new GetAllToggleValueQuery());
        return Ok(toggleValueList);
    }

    [HttpGet("byid-togglevalue")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetToggleValueByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-togglevalue")]
    public async Task<IActionResult> CreateAsync(CreateToggleValueRequest toggleValue)
    {
        var result = await _sender.Send(new CreateToggleValueCommand(toggleValue));
        return Ok(result);
    }

    [HttpPut("update-togglevalue")]
    public async Task<IActionResult> UpdateAsync(UpdateToggleValueRequest toggleValue)
    {
        var result = await _sender.Send(new UpdateToggleValueCommand(toggleValue));
        return Ok(result);
    }

    [HttpDelete("delete-togglevalue")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteToggleValueCommand(Id));
        return Ok(result);
    }
}








































