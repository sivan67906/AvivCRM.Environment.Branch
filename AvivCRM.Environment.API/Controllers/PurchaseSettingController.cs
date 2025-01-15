#region

using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Application.Features.PurchaseSettings.Command.CreatePurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.Command.DeletePurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.Command.UpdatePurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.Query.GetAllPurchaseSetting;
using AvivCRM.Environment.Application.Features.PurchaseSettings.Query.GetPurchaseSettingById;
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
        Domain.Responses.ServerResponse purchaseSettingList = await _sender.Send(new GetAllPurchaseSettingQuery());
        return Ok(purchaseSettingList);
    }

    [HttpGet("byid-purchasesetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetPurchaseSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-purchasesetting")]
    public async Task<IActionResult> CreateAsync(CreatePurchaseSettingRequest purchaseSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreatePurchaseSettingCommand(purchaseSetting));
        return Ok(result);
    }

    [HttpPut("update-purchasesetting")]
    public async Task<IActionResult> UpdateAsync(UpdatePurchaseSettingRequest purchaseSetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdatePurchaseSettingCommand(purchaseSetting));
        return Ok(result);
    }

    [HttpDelete("delete-purchasesetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeletePurchaseSettingCommand(Id));
        return Ok(result);
    }
}