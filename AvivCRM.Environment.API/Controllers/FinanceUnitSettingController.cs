#region

using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.CreateFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.DeleteFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetAllFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetFinanceUnitSettingById;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.UpdateFinanceUnitSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FinanceUnitSettingController : ControllerBase
{
    private readonly ISender _sender;

    public FinanceUnitSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-financeunitsetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var financeUnitSettingList = await _sender.Send(new GetAllFinanceUnitSettingQuery());
        return Ok(financeUnitSettingList);
    }

    [HttpGet("byid-financeunitsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetFinanceUnitSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-financeunitsetting")]
    public async Task<IActionResult> CreateAsync(CreateFinanceUnitSettingRequest financeUnitSetting)
    {
        var result = await _sender.Send(new CreateFinanceUnitSettingCommand(financeUnitSetting));
        return Ok(result);
    }

    [HttpPut("update-financeunitsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateFinanceUnitSettingRequest financeUnitSetting)
    {
        var result = await _sender.Send(new UpdateFinanceUnitSettingCommand(financeUnitSetting));
        return Ok(result);
    }

    [HttpDelete("delete-financeunitsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinanceUnitSettingCommand(Id));
        return Ok(result);
    }
}