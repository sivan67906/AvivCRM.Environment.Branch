using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.Features.TicketGroups.CreateTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.DeleteTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.GetAllTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.GetTicketGroupById;
using AvivCRM.Environment.Application.Features.TicketGroups.UpdateTicketGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketGroupController : ControllerBase
{

    private readonly ISender _sender;
    public TicketGroupController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTicketGroupByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTicketGroupRequest ticketGroup)
    {
        var result = await _sender.Send(new CreateTicketGroupCommand(ticketGroup));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTicketGroupRequest ticketGroup)
    {
        var result = await _sender.Send(new UpdateTicketGroupCommand(ticketGroup));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var ticketGroupList = await _sender.Send(new GetAllTicketGroupQuery());
        return Ok(ticketGroupList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketGroupCommand(Id));
        return Ok(result);
    }
}









