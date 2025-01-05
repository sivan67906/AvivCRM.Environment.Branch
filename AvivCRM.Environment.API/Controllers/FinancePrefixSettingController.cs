using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.CreateFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.DeleteFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetAllFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetFinancePrefixSettingById;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.UpdateFinancePrefixSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinancePrefixSettingController : ControllerBase
{

    private readonly ISender _sender;
    public FinancePrefixSettingController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetFinancePrefixSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateFinancePrefixSettingRequest financePrefixSetting)
    {
        var result = await _sender.Send(new CreateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateFinancePrefixSettingRequest financePrefixSetting)
    {
        var result = await _sender.Send(new UpdateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var financePrefixSettingList = await _sender.Send(new GetAllFinancePrefixSettingQuery());
        return Ok(financePrefixSettingList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinancePrefixSettingCommand(Id));
        return Ok(result);
    }
}