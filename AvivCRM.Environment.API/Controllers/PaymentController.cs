#region

using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Application.Features.Payments.Command.CreatePayment;
using AvivCRM.Environment.Application.Features.Payments.Command.DeletePayment;
using AvivCRM.Environment.Application.Features.Payments.Command.UpdatePayment;
using AvivCRM.Environment.Application.Features.Payments.Query.GetAllPayment;
using AvivCRM.Environment.Application.Features.Payments.Query.GetPaymentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly ISender _sender;

    public PaymentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-payment")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse paymentList = await _sender.Send(new GetAllPaymentQuery());
        return Ok(paymentList);
    }

    [HttpGet("byid-payment")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetPaymentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-payment")]
    public async Task<IActionResult> CreateAsync(CreatePaymentRequest payment)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreatePaymentCommand(payment));
        return Ok(result);
    }

    [HttpPut("update-payment")]
    public async Task<IActionResult> UpdateAsync(UpdatePaymentRequest payment)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdatePaymentCommand(payment));
        return Ok(result);
    }

    [HttpDelete("delete-payment")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeletePaymentCommand(Id));
        return Ok(result);
    }
}