#region

using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Application.Features.Taxes.Command.CreateTax;
using AvivCRM.Environment.Application.Features.Taxes.Command.DeleteTax;
using AvivCRM.Environment.Application.Features.Taxes.Command.UpdateTax;
using AvivCRM.Environment.Application.Features.Taxes.Query.GetAllTax;
using AvivCRM.Environment.Application.Features.Taxes.Query.GetTaxById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaxController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("all-tax")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse taxList = await _sender.Send(new GetAllTaxQuery());
        return Ok(taxList);
    }

    [HttpGet("byid-tax")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTaxByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-tax")]
    public async Task<IActionResult> CreateAsync(CreateTaxRequest tax)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTaxCommand(tax));
        return Ok(result);
    }

    [HttpPut("update-tax")]
    public async Task<IActionResult> UpdateAsync(UpdateTaxRequest tax)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTaxCommand(tax));
        return Ok(result);
    }

    [HttpDelete("delete-tax")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTaxCommand(Id));
        return Ok(result);
    }
}