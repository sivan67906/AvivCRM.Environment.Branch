using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.Features.Contracts.CreateContract;
using AvivCRM.Environment.Application.Features.Contracts.DeleteContract;
using AvivCRM.Environment.Application.Features.Contracts.GetAllContract;
using AvivCRM.Environment.Application.Features.Contracts.GetContractById;
using AvivCRM.Environment.Application.Features.Contracts.UpdateContract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly ISender _sender;
    public ContractController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetContractByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateContractRequest contract)
    {
        var result = await _sender.Send(new CreateContractCommand(contract));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateContractRequest contract)
    {
        await _sender.Send(new UpdateContractCommand(contract));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contractList = await _sender.Send(new GetAllContractQuery());
        return Ok(contractList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteContractCommand(Id));
        return NoContent();
    }
}
