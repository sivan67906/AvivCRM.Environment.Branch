#region

using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.Features.TicketChannels.CreateTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.DeleteTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.GetAllTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.GetTicketChannelById;
using AvivCRM.Environment.Application.Features.TicketChannels.UpdateTicketChannel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketChannelController : ControllerBase
{
    private readonly ISender _sender;

    public TicketChannelController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-ticketchannel")]
    public async Task<IActionResult> GetAllAsync()
    {
        var ticketChannelList = await _sender.Send(new GetAllTicketChannelQuery());
        return Ok(ticketChannelList);
    }

    [HttpGet("byid-ticketchannel")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTicketChannelByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketchannel")]
    public async Task<IActionResult> CreateAsync(CreateTicketChannelRequest ticketChannel)
    {
        var result = await _sender.Send(new CreateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpPut("update-ticketchannel")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketChannelRequest ticketChannel)
    {
        var result = await _sender.Send(new UpdateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpDelete("delete-ticketchannel")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketChannelCommand(Id));
        return Ok(result);
    }
}