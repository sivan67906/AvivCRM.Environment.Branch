#region

using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.CreateFinanceInvoiceSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.DeleteFinanceInvoiceSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetAllFinanceInvoiceSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetFinanceInvoiceSettingById;
using AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.UpdateFinanceInvoiceSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FinanceInvoiceSettingController : ControllerBase
{
    private readonly ISender _sender;

    public FinanceInvoiceSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-financeInvoiceSetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var financeInvoiceSettingList = await _sender.Send(new GetAllFinanceInvoiceSettingQuery());
        return Ok(financeInvoiceSettingList);
    }

    [HttpGet("byid-financeInvoiceSetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetFinanceInvoiceSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-financeInvoiceSetting")]
    public async Task<IActionResult> CreateAsync(CreateFinanceInvoiceSettingRequest financeInvoiceSetting)
    {
        var result = await _sender.Send(new CreateFinanceInvoiceSettingCommand(financeInvoiceSetting));
        return Ok(result);
    }

    [HttpPut("update-financeInvoiceSetting")]
    public async Task<IActionResult> UpdateAsync(UpdateFinanceInvoiceSettingRequest financeInvoiceSetting)
    {
        var result = await _sender.Send(new UpdateFinanceInvoiceSettingCommand(financeInvoiceSetting));
        return Ok(result);
    }

    [HttpDelete("delete-financeInvoiceSetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinanceInvoiceSettingCommand(Id));
        return Ok(result);
    }
}