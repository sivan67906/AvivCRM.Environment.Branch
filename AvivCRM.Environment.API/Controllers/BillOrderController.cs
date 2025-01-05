using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Application.Features.BillOrders.CreateBillOrder;
using AvivCRM.Environment.Application.Features.BillOrders.DeleteBillOrder;
using AvivCRM.Environment.Application.Features.BillOrders.GetAllBillOrder;
using AvivCRM.Environment.Application.Features.BillOrders.GetBillOrderById;
using AvivCRM.Environment.Application.Features.BillOrders.UpdateBillOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BillOrderController : ControllerBase
{
    private readonly ISender _sender;
    public BillOrderController(ISender sender) => _sender = sender;

    [HttpGet("all-billOrder")]
    public async Task<IActionResult> GetAllAsync()
    {
        var billOrderList = await _sender.Send(new GetAllBillOrderQuery());
        return Ok(billOrderList);
    }

    [HttpGet("byid-billOrder")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetBillOrderByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-billOrder")]
    public async Task<IActionResult> CreateAsync(CreateBillOrderRequest billOrder)
    {
        var result = await _sender.Send(new CreateBillOrderCommand(billOrder));
        return Ok(result);
    }

    [HttpPut("update-billOrder")]
    public async Task<IActionResult> UpdateAsync(UpdateBillOrderRequest billOrder)
    {
        var result = await _sender.Send(new UpdateBillOrderCommand(billOrder));
        return Ok(result);
    }

    [HttpDelete("delete-billOrder")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteBillOrderCommand(Id));
        return Ok(result);
    }
}
