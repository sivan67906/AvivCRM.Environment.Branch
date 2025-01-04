using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Application.Features.TicketTypes.CreateTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.DeleteTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.GetAllTicketType;
using AvivCRM.Environment.Application.Features.TicketTypes.GetTicketTypeById;
using AvivCRM.Environment.Application.Features.TicketTypes.UpdateTicketType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketTypeController : ControllerBase
{

    private readonly ISender _sender;
    public TicketTypeController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTicketTypeByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTicketTypeRequest ticketType)
    {
        var result = await _sender.Send(new CreateTicketTypeCommand(ticketType));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTicketTypeRequest ticketType)
    {
        await _sender.Send(new UpdateTicketTypeCommand(ticketType));
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var ticketTypeList = await _sender.Send(new GetAllTicketTypeQuery());
        return Ok(ticketTypeList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _sender.Send(new DeleteTicketTypeCommand(Id));
        return NoContent();
    }
}