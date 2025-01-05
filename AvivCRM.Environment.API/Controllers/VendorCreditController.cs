using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Application.Features.VendorCredits.CreateVendorCredit;
using AvivCRM.Environment.Application.Features.VendorCredits.DeletaVendorCredit;
using AvivCRM.Environment.Application.Features.VendorCredits.GetAllVendorCredit;
using AvivCRM.Environment.Application.Features.VendorCredits.GetVendorCreditById;
using AvivCRM.Environment.Application.Features.VendorCredits.UpdateVendorCredit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VendorCreditController : ControllerBase
{
    private readonly ISender _sender;
    public VendorCreditController(ISender sender) => _sender = sender;

    [HttpGet("all-vendorCredit")]
    public async Task<IActionResult> GetAllAsync()
    {
        var vendorCreditList = await _sender.Send(new GetAllVendorCreditQuery());
        return Ok(vendorCreditList);
    }

    [HttpGet("byid-vendorCredit")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetVendorCreditByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-vendorCredit")]
    public async Task<IActionResult> CreateAsync(CreateVendorCreditRequest vendorCredit)
    {
        var result = await _sender.Send(new CreateVendorCreditCommand(vendorCredit));
        return Ok(result);
    }

    [HttpPut("update-vendorCredit")]
    public async Task<IActionResult> UpdateAsync(UpdateVendorCreditRequest vendorCredit)
    {
        var result = await _sender.Send(new UpdateVendorCreditCommand(vendorCredit));
        return Ok(result);
    }

    [HttpDelete("delete-vendorCredit")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteVendorCreditCommand(Id));
        return Ok(result);
    }
}
