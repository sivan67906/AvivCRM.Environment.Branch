using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Application.Features.Payments.CreatePayment;
using AvivCRM.Environment.Application.Features.Payments.DeletePayment;
using AvivCRM.Environment.Application.Features.Payments.GetAllPayment;
using AvivCRM.Environment.Application.Features.Payments.GetPaymentById;
using AvivCRM.Environment.Application.Features.Payments.UpdatePayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly ISender _sender;
    public PaymentController(ISender sender) => _sender = sender;

    [HttpGet("all-payment")]
    public async Task<IActionResult> GetAllAsync()
    {
        var paymentList = await _sender.Send(new GetAllPaymentQuery());
        return Ok(paymentList);
    }

    [HttpGet("byid-payment")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetPaymentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-payment")]
    public async Task<IActionResult> CreateAsync(CreatePaymentRequest payment)
    {
        var result = await _sender.Send(new CreatePaymentCommand(payment));
        return Ok(result);
    }

    [HttpPut("update-payment")]
    public async Task<IActionResult> UpdateAsync(UpdatePaymentRequest payment)
    {
        await _sender.Send(new UpdatePaymentCommand(payment));
        return NoContent();
    }

    [HttpDelete("delete-payment")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        await _sender.Send(new DeletePaymentCommand(Id));
        return NoContent();
    }
}