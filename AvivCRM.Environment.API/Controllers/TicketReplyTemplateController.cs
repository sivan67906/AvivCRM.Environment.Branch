using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.CreateTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.DeleteTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetAllTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetTicketReplyTemplateById;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.UpdateTicketReplyTemplate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketReplyTemplateController : ControllerBase
{

    private readonly ISender _sender;
    public TicketReplyTemplateController(ISender sender) => _sender = sender;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetTicketReplyTemplateByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        var result = await _sender.Send(new CreateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        var result = await _sender.Send(new UpdateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var ticketReplyTemplateList = await _sender.Send(new GetAllTicketReplyTemplateQuery());
        return Ok(ticketReplyTemplateList);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketReplyTemplateCommand(Id));
        return Ok(result);
    }
}