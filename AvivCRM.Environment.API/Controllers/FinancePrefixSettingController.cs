#region

using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.CreateFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.DeleteFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetAllFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetFinancePrefixSettingById;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.UpdateFinancePrefixSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FinancePrefixSettingController : ControllerBase
{
    private readonly ISender _sender;

    public FinancePrefixSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-financeprefixsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var financePrefixSettingList = await _sender.Send(new GetAllFinancePrefixSettingQuery());
        return Ok(financePrefixSettingList);
    }

    [HttpGet("byid-financeprefixsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetFinancePrefixSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-financeprefixsetting")]
    public async Task<IActionResult> CreateAsync(CreateFinancePrefixSettingRequest financePrefixSetting)
    {
        var result = await _sender.Send(new CreateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpPut("update-financeprefixsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateFinancePrefixSettingRequest financePrefixSetting)
    {
        var result = await _sender.Send(new UpdateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpDelete("delete-financeprefixsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinancePrefixSettingCommand(Id));
        return Ok(result);
    }
}