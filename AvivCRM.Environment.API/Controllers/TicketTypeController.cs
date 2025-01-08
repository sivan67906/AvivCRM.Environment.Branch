#region

using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Application.Features.TicketTypes.CreateTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.DeleteTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.GetAllTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.GetTicketTypeById;
using AvivCRM.Environment.Application.Features.TicketTypes.UpdateTicketType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketTypeController : ControllerBase
{
    private readonly ISender _sender;

    public TicketTypeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-tickettype")]
    public async Task<IActionResult> GetAllAsync()
    {
        var ticketTypeList = await _sender.Send(new GetAllTicketTypeQuery());
        return Ok(ticketTypeList);
    }

    [HttpGet("byid-tickettype")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTicketTypeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-tickettype")]
    public async Task<IActionResult> CreateAsync(CreateTicketTypeRequest ticketType)
    {
        var result = await _sender.Send(new CreateTicketTypeCommand(ticketType));
        return Ok(result);
    }

    [HttpPut("update-tickettype")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketTypeRequest ticketType)
    {
        var result = await _sender.Send(new UpdateTicketTypeCommand(ticketType));
        return Ok(result);
    }

    [HttpDelete("delete-tickettype")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketTypeCommand(Id));
        return Ok(result);
    }
}