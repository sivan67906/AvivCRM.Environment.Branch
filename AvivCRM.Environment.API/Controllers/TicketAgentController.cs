using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.DeleteTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.GetAllTicketAgent;
using AvivCRM.Environment.Application.Features.TicketAgents.GetTicketAgentById;
using AvivCRM.Environment.Application.Features.TicketAgents.UpdateTicketAgent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketAgentController : ControllerBase
{

    private readonly ISender _sender;
    public TicketAgentController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTicketAgentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTicketAgentRequest ticketAgent)
    {
        var result = await _sender.Send(new CreateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTicketAgentRequest ticketAgent)
    {
        var result = await _sender.Send(new UpdateTicketAgentCommand(ticketAgent));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var ticketAgentList = await _sender.Send(new GetAllTicketAgentQuery());
        return Ok(ticketAgentList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketAgentCommand(Id));
        return Ok(result);
    }
}