#region

using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.Command.CreateLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.Command.DeleteLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.Command.UpdateLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.Query.GetAllLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.Query.GetLeadStatusById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadStatusController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("all-leadstatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse leadStatusList = await _sender.Send(new GetAllLeadStatusQuery());
        return Ok(leadStatusList);
    }

    [HttpGet("byid-leadstatus")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetLeadStatusByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadstatus")]
    public async Task<IActionResult> CreateAsync(CreateLeadStatusRequest leadStatus)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpPut("update-leadstatus")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadStatusRequest leadStatus)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpDelete("delete-leadstatus")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteLeadStatusCommand(Id));
        return Ok(result);
    }
}