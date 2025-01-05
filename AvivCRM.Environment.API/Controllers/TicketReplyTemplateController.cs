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

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetTicketReplyTemplateByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        var result = await _sender.Send(new CreateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        var result = await _sender.Send(new UpdateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var ticketReplyTemplateList = await _sender.Send(new GetAllTicketReplyTemplateQuery());
        return Ok(ticketReplyTemplateList);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteTicketReplyTemplateCommand(Id));
        return Ok(result);
    }
}