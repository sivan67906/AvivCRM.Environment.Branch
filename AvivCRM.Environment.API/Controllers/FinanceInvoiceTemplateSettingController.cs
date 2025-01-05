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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetFinanceInvoiceTemplateSettingByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateFinanceInvoiceTemplateSettingRequest financeInvoiceTemplateSetting)
    {
        var result = await _sender.Send(new CreateFinanceInvoiceTemplateSettingCommand(financeInvoiceTemplateSetting));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateFinanceInvoiceTemplateSettingRequest financeInvoiceTemplateSetting)
    {
        var result = await _sender.Send(new UpdateFinanceInvoiceTemplateSettingCommand(financeInvoiceTemplateSetting));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var financeInvoiceTemplateSettingList = await _sender.Send(new GetAllFinanceInvoiceTemplateSettingQuery());
        return Ok(financeInvoiceTemplateSettingList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteFinanceInvoiceTemplateSettingCommand(Id));
        return Ok(result);
    }
}









