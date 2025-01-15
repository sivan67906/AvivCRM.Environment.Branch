#region

using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.Command.CreateLeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.Command.DeleteLeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.Command.UpdateLeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.Query.GetAllLeadAgents;
using AvivCRM.Environment.Application.Features.LeadAgents.Query.GetLeadAgentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadAgentController : ControllerBase
{
    private readonly ISender _sender;

    public LeadAgentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-leadagent")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse leadAgentList = await _sender.Send(new GetAllLeadAgentsQuery());
        return Ok(leadAgentList);
    }

    [HttpGet("byid-leadagent")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetLeadAgentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadagent")]
    public async Task<IActionResult> CreateAsync(CreateLeadAgentRequest leadAgent)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpPut("update-leadagent")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadAgentRequest leadAgent)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpDelete("delete-leadagent")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteLeadAgentCommand(Id));
        return Ok(result);
    }
}