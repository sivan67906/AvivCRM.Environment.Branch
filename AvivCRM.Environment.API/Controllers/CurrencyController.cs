using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.Features.Currencies.CreateCurrency;
using AvivCRM.Environment.Application.Features.Currencies.DeleteCurrency;
using AvivCRM.Environment.Application.Features.Currencies.GetAllCurrency;
using AvivCRM.Environment.Application.Features.Currencies.GetCurrencyById;
using AvivCRM.Environment.Application.Features.Currencies.UpdateCurrency;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ISender _sender;
    public CurrencyController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetCurrencyByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCurrencyRequest currency)
    {
        var result = await _sender.Send(new CreateCurrencyCommand(currency));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCurrencyRequest currency)
    {
        await _sender.Send(new UpdateCurrencyCommand(currency));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var currencyList = await _sender.Send(new GetAllCurrencyQuery());
        return Ok(currencyList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteCurrencyCommand(Id));
        return NoContent();
    }
}
