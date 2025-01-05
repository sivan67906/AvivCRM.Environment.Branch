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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTaxByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTaxRequest tax)
    {
        var result = await _sender.Send(new CreateTaxCommand(tax));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTaxRequest tax)
    {
        await _sender.Send(new UpdateTaxCommand(tax));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var taxList = await _sender.Send(new GetAllTaxQuery());
        return Ok(taxList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteTaxCommand(Id));
        return NoContent();
    }
}
