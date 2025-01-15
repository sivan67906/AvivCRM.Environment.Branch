#region

using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.Features.TicketChannels.Command.CreateTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.Command.DeleteTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.Command.UpdateTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.Query.GetAllTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.Query.GetTicketChannelById;
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
        Domain.Responses.ServerResponse ticketChannelList = await _sender.Send(new GetAllTicketChannelQuery());
        return Ok(ticketChannelList);
    }

    [HttpGet("byid-ticketchannel")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTicketChannelByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketchannel")]
    public async Task<IActionResult> CreateAsync(CreateTicketChannelRequest ticketChannel)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpPut("update-ticketchannel")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketChannelRequest ticketChannel)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpDelete("delete-ticketchannel")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTicketChannelCommand(Id));
        return Ok(result);
    }
}