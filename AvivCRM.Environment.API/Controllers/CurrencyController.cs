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

    [HttpGet("all-currency")]
    public async Task<IActionResult> GetAllAsync()
    {
        var currencyList = await _sender.Send(new GetAllCurrencyQuery());
        return Ok(currencyList);
    }

    [HttpGet("byid-currency")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetCurrencyByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-currency")]
    public async Task<IActionResult> CreateAsync(CreateCurrencyRequest currency)
    {
        var result = await _sender.Send(new CreateCurrencyCommand(currency));
        return Ok(result);
    }

    [HttpPut("update-currency")]
    public async Task<IActionResult> UpdateAsync(UpdateCurrencyRequest currency)
    {
        var result = await _sender.Send(new UpdateCurrencyCommand(currency));
        return Ok(result);
    }

    [HttpDelete("delete-currency")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteCurrencyCommand(Id));
        return Ok(result);
    }
}
