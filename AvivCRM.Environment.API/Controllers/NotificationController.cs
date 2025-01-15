using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Application.Features.Notifications.Command.CreateNotification;
using AvivCRM.Environment.Application.Features.Notifications.Command.DeleteNotification;
using AvivCRM.Environment.Application.Features.Notifications.Command.UpdateNotification;
using AvivCRM.Environment.Application.Features.Notifications.Query.GetAllNotification;
using AvivCRM.Environment.Application.Features.Notifications.Query.GetNotificationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class NotificationController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("all-leadstatus")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse notificationList = await _sender.Send(new GetAllNotificationQuery());
        return Ok(notificationList);
    }

    [HttpGet("byid-leadstatus")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetNotificationByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-leadstatus")]
    public async Task<IActionResult> CreateAsync(CreateNotificationRequest notification)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateNotificationCommand(notification));
        return Ok(result);
    }

    [HttpPut("update-leadstatus")]
    public async Task<IActionResult> UpdateAsync(UpdateNotificationRequest notification)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateNotificationCommand(notification));
        return Ok(result);
    }

    [HttpDelete("delete-leadstatus")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteNotificationCommand(Id));
        return Ok(result);
    }
}

