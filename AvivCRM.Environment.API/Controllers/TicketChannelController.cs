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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTicketChannelByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTicketChannelRequest ticketChannel)
    {
        var result = await _sender.Send(new CreateTicketChannelCommand(ticketChannel));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTicketChannelRequest ticketChannel)
    {
        await _sender.Send(new UpdateTicketChannelCommand(ticketChannel));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var ticketChannelList = await _sender.Send(new GetAllTicketChannelQuery());
        return Ok(ticketChannelList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteTicketChannelCommand(Id));
        return NoContent();
    }
}









