#region

using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.Features.Currencies.Command.CreateCurrency;
using AvivCRM.Environment.Application.Features.Currencies.Command.DeleteCurrency;
using AvivCRM.Environment.Application.Features.Currencies.Command.UpdateCurrency;
using AvivCRM.Environment.Application.Features.Currencies.Query.GetAllCurrency;
using AvivCRM.Environment.Application.Features.Currencies.Query.GetCurrencyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ISender _sender;

    public CurrencyController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-currency")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse currencyList = await _sender.Send(new GetAllCurrencyQuery());
        return Ok(currencyList);
    }

    [HttpGet("byid-currency")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetCurrencyByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-currency")]
    public async Task<IActionResult> CreateAsync(CreateCurrencyRequest currency)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateCurrencyCommand(currency));
        return Ok(result);
    }

    [HttpPut("update-currency")]
    public async Task<IActionResult> UpdateAsync(UpdateCurrencyRequest currency)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateCurrencyCommand(currency));
        return Ok(result);
    }

    [HttpDelete("delete-currency")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteCurrencyCommand(Id));
        return Ok(result);
    }
}