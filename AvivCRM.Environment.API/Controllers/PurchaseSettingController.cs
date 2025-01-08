#region

using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Application.Features.PurchaseSettings.CreatePurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.DeletePurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.GetAllPurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.GetPurchaseSettingById;
using AvivCRM.Environment.Application.Features.PurchaseSettings.UpdatePurchaseSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PurchaseSettingController : ControllerBase
{
    private readonly ISender _sender;

    public PurchaseSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-purchasesetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        var purchaseSettingList = await _sender.Send(new GetAllPurchaseSettingQuery());
        return Ok(purchaseSettingList);
    }

    [HttpGet("byid-purchasesetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetPurchaseSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-purchasesetting")]
    public async Task<IActionResult> CreateAsync(CreatePurchaseSettingRequest purchaseSetting)
    {
        var result = await _sender.Send(new CreatePurchaseSettingCommand(purchaseSetting));
        return Ok(result);
    }

    [HttpPut("update-purchasesetting")]
    public async Task<IActionResult> UpdateAsync(UpdatePurchaseSettingRequest purchaseSetting)
    {
        var result = await _sender.Send(new UpdatePurchaseSettingCommand(purchaseSetting));
        return Ok(result);
    }

    [HttpDelete("delete-purchasesetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeletePurchaseSettingCommand(Id));
        return Ok(result);
    }
}