using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Application.Features.Clients.CreateClient;
using AvivCRM.Environment.Application.Features.Clients.DeleteClient;
using AvivCRM.Environment.Application.Features.Clients.GetAllClient;
using AvivCRM.Environment.Application.Features.Clients.GetClientById;
using AvivCRM.Environment.Application.Features.Clients.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;
    public ClientController(ISender sender) => _sender = sender;

    [HttpGet("all-client")]
    public async Task<IActionResult> GetAllAsync()
    {
        var clientList = await _sender.Send(new GetAllClientQuery());
        return Ok(clientList);
    }

    [HttpGet("byid-client")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetClientByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-client")]
    public async Task<IActionResult> CreateAsync(CreateClientRequest client)
    {
        var result = await _sender.Send(new CreateClientCommand(client));
        return Ok(result);
    }

    [HttpPut("update-client")]
    public async Task<IActionResult> UpdateAsync(UpdateClientRequest client)
    {
        await _sender.Send(new UpdateClientCommand(client));
        return NoContent();
    }

    [HttpDelete("delete-client")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        await _sender.Send(new DeleteClientCommand(Id));
        return NoContent();
    }
}
