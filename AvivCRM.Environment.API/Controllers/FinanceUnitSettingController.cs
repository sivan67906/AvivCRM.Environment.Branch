using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.CreateFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.DeleteFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetAllFinanceUnitSetting;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetFinanceUnitSettingById;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.UpdateFinanceUnitSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceUnitSettingController : ControllerBase
{

    private readonly ISender _sender;
    public FinanceUnitSettingController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetFinanceUnitSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateFinanceUnitSettingRequest financeUnitSetting)
    {
        var result = await _sender.Send(new CreateFinanceUnitSettingCommand(financeUnitSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateFinanceUnitSettingRequest financeUnitSetting)
    {
        await _sender.Send(new UpdateFinanceUnitSettingCommand(financeUnitSetting));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var financeUnitSettingList = await _sender.Send(new GetAllFinanceUnitSettingQuery());
        return Ok(financeUnitSettingList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteFinanceUnitSettingCommand(Id));
        return NoContent();
    }
}