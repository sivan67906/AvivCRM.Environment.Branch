using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.CreateLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.DeleteLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.GetAllLeadStatus;
using AvivCRM.Environment.Application.Features.LeadStatuss.GetLeadStatusById;
using AvivCRM.Environment.Application.Features.LeadStatuss.UpdateLeadStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeadStatusController : ControllerBase
{
    private readonly ISender _sender;
    public LeadStatusController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetLeadStatusByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateLeadStatusRequest leadStatus)
    {
        var result = await _sender.Send(new CreateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateLeadStatusRequest leadStatus)
    {
        var result = await _sender.Send(new UpdateLeadStatusCommand(leadStatus));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var leadStatusList = await _sender.Send(new GetAllLeadStatusQuery());
        return Ok(leadStatusList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteLeadStatusCommand(Id));
        return Ok(result);
    }
}
