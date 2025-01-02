using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.Features.LeadSources.DeleteLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.GetAllLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.UpdateLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.CreateLeadSource;
using AvivCRM.Environment.Application.Features.LeadSources.GetLeadSourceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadSourceController : ControllerBase
{

    private readonly ISender _sender;
    public LeadSourceController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(GetLeadSource leadSource)
    {
        var result = await _sender.Send(new GetLeadSourceByIdQuery(leadSource.Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateLeadSourceRequest leadSource)
    {
        var result = await _sender.Send(new CreateLeadSourceCommand(leadSource));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateLeadSourceRequest leadSource)
    {
        await _sender.Send(new UpdateLeadSourceCommand(leadSource));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var leadSourceList = await _sender.Send(new GetAllLeadSourceQuery());
        return Ok(leadSourceList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteLeadSourceCommand(Id));
        return NoContent();
    }
}