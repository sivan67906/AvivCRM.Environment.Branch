#region

using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.DeleteTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.GetAllTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.GetTicketAgentById;
using AvivCRM.Environment.Application.Features.TicketAgents.UpdateTicketAgent;
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
        var ticketAgentList = await _sender.Send(new GetAllTicketAgentQuery());
        return Ok(ticketAgentList);
    }

    [HttpGet("byid-ticketagent")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTicketAgentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketagent")]
    public async Task<IActionResult> CreateAsync(CreateTicketAgentRequest ticketAgent)
    {
        var result = await _sender.Send(new CreateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpPut("update-ticketagent")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketAgentRequest ticketAgent)
    {
        var result = await _sender.Send(new UpdateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpDelete("delete-ticketagent")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketAgentCommand(Id));
        return Ok(result);
    }
}