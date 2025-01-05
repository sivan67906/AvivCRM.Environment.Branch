using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.CreateFinanceInvoiceTemplateSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.DeleteFinanceInvoiceTemplateSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetAllFinanceInvoiceTemplateSetting;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetFinanceInvoiceTemplateSettingById;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.UpdateFinanceInvoiceTemplateSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceInvoiceTemplateSettingController : ControllerBase
{

    private readonly ISender _sender;
    public FinanceInvoiceTemplateSettingController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetFinanceInvoiceTemplateSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateFinanceInvoiceTemplateSettingRequest financeInvoiceTemplateSetting)
    {
        var result = await _sender.Send(new CreateFinanceInvoiceTemplateSettingCommand(financeInvoiceTemplateSetting));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateFinanceInvoiceTemplateSettingRequest financeInvoiceTemplateSetting)
    {
        var result = await _sender.Send(new UpdateFinanceInvoiceTemplateSettingCommand(financeInvoiceTemplateSetting));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var financeInvoiceTemplateSettingList = await _sender.Send(new GetAllFinanceInvoiceTemplateSettingQuery());
        return Ok(financeInvoiceTemplateSettingList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinanceInvoiceTemplateSettingCommand(Id));
        return Ok(result);
    }
}