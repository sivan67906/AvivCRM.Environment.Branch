using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.Features.LeadSources.CreateLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.DeleteLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.GetAllLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.GetLeadSourceById;
using AvivCRM.Environment.Application.Features.LeadSources.UpdateLeadSource;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadSourceController : ControllerBase
{

    private readonly ISender _sender;
    public LeadSourceController(ISender sender) => _sender = sender;

    [HttpGet("all-leadsource")]
    public async Task<IActionResult> GetAllAsync()
    {
        var leadSourceList = await _sender.Send(new GetAllLeadSourceQuery());
        return Ok(leadSourceList);
    }

    [HttpGet("byid-leadsource")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetLeadSourceByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadsource")]
    public async Task<IActionResult> CreateAsync(CreateLeadSourceRequest leadSource)
    {
        var result = await _sender.Send(new CreateLeadSourceCommand(leadSource));
        return Ok(result);
    }

    [HttpPut("update-leadsource")]
    public async Task<IActionResult> UpdateAsync(UpdateLeadSourceRequest leadSource)
    {
        var result = await _sender.Send(new UpdateLeadSourceCommand(leadSource));
        return Ok(result);
    }

    [HttpDelete("delete-leadsource")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadSourceCommand(Id));
        return Ok(result);
    }
}