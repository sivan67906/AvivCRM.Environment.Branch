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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetPaymentByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePaymentRequest payment)
    {
        var result = await _sender.Send(new CreatePaymentCommand(payment));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdatePaymentRequest payment)
    {
        await _sender.Send(new UpdatePaymentCommand(payment));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var paymentList = await _sender.Send(new GetAllPaymentQuery());
        return Ok(paymentList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeletePaymentCommand(Id));
        return NoContent();
    }
}