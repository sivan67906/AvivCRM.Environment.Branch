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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetFinancePrefixSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateFinancePrefixSettingRequest financePrefixSetting)
    {
        var result = await _sender.Send(new CreateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateFinancePrefixSettingRequest financePrefixSetting)
    {
        await _sender.Send(new UpdateFinancePrefixSettingCommand(financePrefixSetting));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var financePrefixSettingList = await _sender.Send(new GetAllFinancePrefixSettingQuery());
        return Ok(financePrefixSettingList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteFinancePrefixSettingCommand(Id));
        return NoContent();
    }
}