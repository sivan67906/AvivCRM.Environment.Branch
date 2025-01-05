using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Application.Features.Taxes.CreateTax;
using AvivCRM.Environment.Application.Features.Taxes.DeleteTax;
using AvivCRM.Environment.Application.Features.Taxes.GetAllTax;
using AvivCRM.Environment.Application.Features.Taxes.GetTaxById;
using AvivCRM.Environment.Application.Features.Taxes.UpdateTax;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaxController : ControllerBase
{
    private readonly ISender _sender;
    public TaxController(ISender sender) => _sender = sender;

    [HttpGet("all-tax")]
    public async Task<IActionResult> GetAllAsync()
    {
        var taxList = await _sender.Send(new GetAllTaxQuery());
        return Ok(taxList);
    }

    [HttpGet("byid-tax")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTaxByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-tax")]
    public async Task<IActionResult> CreateAsync(CreateTaxRequest tax)
    {
        var result = await _sender.Send(new CreateTaxCommand(tax));
        return Ok(result);
    }

    [HttpPut("update-tax")]
    public async Task<IActionResult> UpdateAsync(UpdateTaxRequest tax)
    {
        var result = await _sender.Send(new UpdateTaxCommand(tax));
        return Ok(result);
    }

    [HttpDelete("delete-tax")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTaxCommand(Id));
        return Ok(result);
    }
}
