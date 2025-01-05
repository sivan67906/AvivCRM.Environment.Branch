using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.Features.TicketChannels.CreateTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.DeleteTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.GetAllTicketChannel;
using AvivCRM.Environment.Application.Features.TicketChannels.GetTicketChannelById;
using AvivCRM.Environment.Application.Features.TicketChannels.UpdateTicketChannel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketChannelController : ControllerBase
{

    private readonly ISender _sender;
    public TicketChannelController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTicketChannelByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTicketChannelRequest ticketChannel)
    {
        var result = await _sender.Send(new CreateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketChannelRequest ticketChannel)
    {
        var result = await _sender.Send(new UpdateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var ticketChannelList = await _sender.Send(new GetAllTicketChannelQuery());
        return Ok(ticketChannelList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketChannelCommand(Id));
        return Ok(result);
    }
}