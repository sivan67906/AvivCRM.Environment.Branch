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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetLeadAgentByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateLeadAgentRequest leadAgent)
    {
        var result = await _sender.Send(new CreateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateLeadAgentRequest leadAgent)
    {
        var result = await _sender.Send(new UpdateLeadAgentCommand(leadAgent));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var leadAgentList = await _sender.Send(new GetAllLeadAgentsQuery());
        return Ok(leadAgentList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadAgentCommand(Id));
        return Ok(result);
    }
}
