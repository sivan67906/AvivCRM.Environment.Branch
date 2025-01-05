using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Application.Features.PurchaseOrders.CreatePurchaseOrder;
using AvivCRM.Environment.Application.Features.PurchaseOrders.DeletePurchaseOrder;
using AvivCRM.Environment.Application.Features.PurchaseOrders.GetAllPurchaseOrder;
using AvivCRM.Environment.Application.Features.PurchaseOrders.GetPurchaseOrderById;
using AvivCRM.Environment.Application.Features.PurchaseOrders.UpdatePurchaseOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly ISender _sender;
    public PurchaseOrderController(ISender sender) => _sender = sender;

    [HttpGet("all-purchaseOrder")]
    public async Task<IActionResult> GetAllAsync()
    {
        var purchaseOrderList = await _sender.Send(new GetAllPurchaseOrderQuery());
        return Ok(purchaseOrderList);
    }

    [HttpGet("byid-purchaseOrder")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetPurchaseOrderByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-purchaseOrder")]
    public async Task<IActionResult> CreateAsync(CreatePurchaseOrderRequest purchaseOrder)
    {
        var result = await _sender.Send(new CreatePurchaseOrderCommand(purchaseOrder));
        return Ok(result);
    }

    [HttpPut("update-purchaseOrder")]
    public async Task<IActionResult> UpdateAsync(UpdatePurchaseOrderRequest purchaseOrder)
    {
        var result = await _sender.Send(new UpdatePurchaseOrderCommand(purchaseOrder));
        return Ok(result);
    }

    [HttpDelete("delete-purchaseOrder")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeletePurchaseOrderCommand(Id));
        return Ok(result);
    }
}
