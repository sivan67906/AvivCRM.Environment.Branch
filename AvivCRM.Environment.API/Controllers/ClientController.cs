#region

using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Application.Features.Clients.Command.CreateClient;
using AvivCRM.Environment.Application.Features.Clients.Command.DeleteClient;
using AvivCRM.Environment.Application.Features.Clients.Command.UpdateClient;
using AvivCRM.Environment.Application.Features.Clients.Query.GetAllClient;
using AvivCRM.Environment.Application.Features.Clients.Query.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-client")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse clientList = await _sender.Send(new GetAllClientQuery());
        return Ok(clientList);
    }

    [HttpGet("byid-client")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetClientByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-client")]
    public async Task<IActionResult> CreateAsync(CreateClientRequest client)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateClientCommand(client));
        return Ok(result);
    }

    [HttpPut("update-client")]
    public async Task<IActionResult> UpdateAsync(UpdateClientRequest client)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateClientCommand(client));
        return Ok(result);
    }

    [HttpDelete("delete-client")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteClientCommand(Id));
        return Ok(result);
    }
}