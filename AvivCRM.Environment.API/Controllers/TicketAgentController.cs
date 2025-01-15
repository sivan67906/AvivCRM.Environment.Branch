#region

using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.Features.TicketAgents.Command.CreateTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.Command.DeleteTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.Command.UpdateTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.Query.GetAllTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.Query.GetTicketAgentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketAgentController : ControllerBase
{
    private readonly ISender _sender;

    public TicketAgentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-ticketagent")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse ticketAgentList = await _sender.Send(new GetAllTicketAgentQuery());
        return Ok(ticketAgentList);
    }

    [HttpGet("byid-ticketagent")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTicketAgentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketagent")]
    public async Task<IActionResult> CreateAsync(CreateTicketAgentRequest ticketAgent)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpPut("update-ticketagent")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketAgentRequest ticketAgent)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpDelete("delete-ticketagent")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTicketAgentCommand(Id));
        return Ok(result);
    }
}