#region

using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.Features.TicketGroups.Command.CreateTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.Command.DeleteTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.Command.UpdateTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.Query.GetAllTicketGroup;
using AvivCRM.Environment.Application.Features.TicketGroups.Query.GetTicketGroupById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketGroupController : ControllerBase
{
    private readonly ISender _sender;

    public TicketGroupController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-ticketgroup")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse ticketGroupList = await _sender.Send(new GetAllTicketGroupQuery());
        return Ok(ticketGroupList);
    }

    [HttpGet("byid-ticketgroup")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTicketGroupByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketgroup")]
    public async Task<IActionResult> CreateAsync(CreateTicketGroupRequest ticketGroup)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTicketGroupCommand(ticketGroup));
        return Ok(result);
    }

    [HttpPut("update-ticketgroup")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketGroupRequest ticketGroup)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTicketGroupCommand(ticketGroup));
        return Ok(result);
    }

    [HttpDelete("delete-ticketgroup")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTicketGroupCommand(Id));
        return Ok(result);
    }
}