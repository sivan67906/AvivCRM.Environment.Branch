#region

using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.CreateFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.DeleteFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.UpdateFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetAllFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetFinanceUnitSettingById;
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
        Domain.Responses.ServerResponse financeUnitSettingList = await _sender.Send(new GetAllFinanceUnitSettingQuery());
        return Ok(financeUnitSettingList);
    }

    [HttpGet("byid-financeunitsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetFinanceUnitSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-financeunitsetting")]
    public async Task<IActionResult> CreateAsync(CreateFinanceUnitSettingRequest financeUnitSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateFinanceUnitSettingCommand(financeUnitSetting));
        return Ok(result);
    }

    [HttpPut("update-financeunitsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateFinanceUnitSettingRequest financeUnitSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateFinanceUnitSettingCommand(financeUnitSetting));
        return Ok(result);
    }

    [HttpDelete("delete-financeunitsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteFinanceUnitSettingCommand(Id));
        return Ok(result);
    }
}