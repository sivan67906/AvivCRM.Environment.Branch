using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.CreateLeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.DeleteLeadAgent;
using AvivCRM.Environment.Application.Features.LeadAgents.GetAllLeadAgents;
using AvivCRM.Environment.Application.Features.LeadAgents.GetLeadAgentById;
using AvivCRM.Environment.Application.Features.LeadAgents.UpdateLeadAgent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadAgentController : ControllerBase
{
    private readonly ISender _sender;
    public LeadAgentController(ISender sender) => _sender = sender;

    [HttpGet("all-leadsgent")]
    public async Task<IActionResult> GetAllAsync()
    {
        var leadAgentList = await _sender.Send(new GetAllLeadAgentsQuery());
        return Ok(leadAgentList);
    }

    [HttpGet("byid-leadsgent")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetLeadAgentByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadsgent")]
    public async Task<IActionResult> CreateAsync(CreateLeadAgentRequest leadAgent)
    {
        var result = await _sender.Send(new CreateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpPut("update-leadsgent")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadAgentRequest leadAgent)
    {
        var result = await _sender.Send(new UpdateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpDelete("delete-leadsgent")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadAgentCommand(Id));
        return Ok(result);
    }
}
