#region

using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.Features.Contracts.CreateContract;
using AvivCRM.Environment.Application.Features.Contracts.DeleteContract;
using AvivCRM.Environment.Application.Features.Contracts.GetAllContract;
using AvivCRM.Environment.Application.Features.Contracts.GetContractById;
using AvivCRM.Environment.Application.Features.Contracts.UpdateContract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly ISender _sender;

    public ContractController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-contract")]
    public async Task<IActionResult> GetAllAsync()
    {
        var contractList = await _sender.Send(new GetAllContractQuery());
        return Ok(contractList);
    }

    [HttpGet("byid-contract")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetContractByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-contract")]
    public async Task<IActionResult> CreateAsync(CreateContractRequest contract)
    {
        var result = await _sender.Send(new CreateContractCommand(contract));
        return Ok(result);
    }

    [HttpPut("update-contract")]
    public async Task<IActionResult> UpdateAsync(UpdateContractRequest contract)
    {
        var result = await _sender.Send(new UpdateContractCommand(contract));
        return Ok(result);
    }

    [HttpDelete("delete-contract")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteContractCommand(Id));
        return Ok(result);
    }
}