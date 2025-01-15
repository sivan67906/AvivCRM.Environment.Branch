#region

using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.Command.CreateTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.Command.DeleteTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.Command.UpdateTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.Query.GetAllTicketReplyTemplate;
using AvivCRM.Environment.Application.Features.TicketReplyTemplates.Query.GetTicketReplyTemplateById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TicketReplyTemplateController : ControllerBase
{
    private readonly ISender _sender;

    public TicketReplyTemplateController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-ticketreplytemplate")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse ticketReplyTemplateList = await _sender.Send(new GetAllTicketReplyTemplateQuery());
        return Ok(ticketReplyTemplateList);
    }

    [HttpGet("byid-ticketreplytemplate")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetTicketReplyTemplateByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-ticketreplytemplate")]
    public async Task<IActionResult> CreateAsync(CreateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpPut("update-ticketreplytemplate")]
    public async Task<IActionResult> UpdateAsync(UpdateTicketReplyTemplateRequest ticketReplyTemplate)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateTicketReplyTemplateCommand(ticketReplyTemplate));
        return Ok(result);
    }

    [HttpDelete("delete-ticketreplytemplate")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteTicketReplyTemplateCommand(Id));
        return Ok(result);
    }
}