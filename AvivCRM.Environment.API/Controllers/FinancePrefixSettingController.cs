#region

using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.CreateFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.DeleteFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.UpdateFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.Query.GetAllFinancePrefixSetting;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.Query.GetFinancePrefixSettingById;
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
        Domain.Responses.ServerResponse financePrefixSettingList = await _sender.Send(new GetAllFinancePrefixSettingQuery());
        return Ok(financePrefixSettingList);
    }

    [HttpGet("byid-financeprefixsetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetFinancePrefixSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-financeprefixsetting")]
    public async Task<IActionResult> CreateAsync(CreateFinancePrefixSettingRequest financePrefixSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpPut("update-financeprefixsetting")]
    public async Task<IActionResult> UpdateAsync(UpdateFinancePrefixSettingRequest financePrefixSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateFinancePrefixSettingCommand(financePrefixSetting));
        return Ok(result);
    }

    [HttpDelete("delete-financeprefixsetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteFinancePrefixSettingCommand(Id));
        return Ok(result);
    }
}