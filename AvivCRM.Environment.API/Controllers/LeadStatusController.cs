#region

using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuses.CreateLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuses.DeleteLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuses.GetAllLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuses.GetLeadStatusById;
using AvivCRM.Environment.Application.Features.LeadStatuses.UpdateLeadStatus;
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
        var leadStatusList = await _sender.Send(new GetAllLeadStatusQuery());
        return Ok(leadStatusList);
    }

    [HttpGet("byid-leadstatus")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetLeadStatusByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadstatus")]
    public async Task<IActionResult> CreateAsync(CreateLeadStatusRequest leadStatus)
    {
        var result = await _sender.Send(new CreateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpPut("update-leadstatus")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadStatusRequest leadStatus)
    {
        var result = await _sender.Send(new UpdateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpDelete("delete-leadstatus")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadStatusCommand(Id));
        return Ok(result);
    }
}