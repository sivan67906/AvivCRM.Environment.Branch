#region

using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.Features.LeadSources.Command.CreateLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.Command.DeleteLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.Command.UpdateLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.Query.GetAllLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.Query.GetLeadSourceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadSourceController : ControllerBase
{
    private readonly ISender _sender;

    public LeadSourceController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-leadsource")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse leadSourceList = await _sender.Send(new GetAllLeadSourceQuery());
        return Ok(leadSourceList);
    }

    [HttpGet("byid-leadsource")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetLeadSourceByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadsource")]
    public async Task<IActionResult> CreateAsync(CreateLeadSourceRequest leadSource)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateLeadSourceCommand(leadSource));
        return Ok(result);
    }

    [HttpPut("update-leadsource")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadSourceRequest leadSource)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateLeadSourceCommand(leadSource));
        return Ok(result);
    }

    [HttpDelete("delete-leadsource")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteLeadSourceCommand(Id));
        return Ok(result);
    }
}