using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Application.Features.Messages.CreateMessage;
using AvivCRM.Environment.Application.Features.Messages.DeleteMessage;
using AvivCRM.Environment.Application.Features.Messages.GetAllMessage;
using AvivCRM.Environment.Application.Features.Messages.GetMessageById;
using AvivCRM.Environment.Application.Features.Messages.UpdateMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class MessageController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("all-leadstatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        var messageList = await _sender.Send(new GetAllMessageQuery());
        return Ok(messageList);
    }

    [HttpGet("byid-leadstatus")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetMessageByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadstatus")]
    public async Task<IActionResult> CreateAsync(CreateMessageRequest message)
    {
        var result = await _sender.Send(new CreateMessageCommand(message));
        return Ok(result);
    }

    [HttpPut("update-leadstatus")]
    public async Task<IActionResult> UpdateAsync(UpdateMessageRequest message)
    {
        var result = await _sender.Send(new UpdateMessageCommand(message));
        return Ok(result);
    }

    [HttpDelete("delete-leadstatus")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteMessageCommand(Id));
        return Ok(result);
    }
}

