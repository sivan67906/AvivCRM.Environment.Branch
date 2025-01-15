#region

using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Application.Features.NotificationMains.Command.CreateNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.Command.DeleteNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.Command.UpdateNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.Query.GetAllNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.Query.GetNotificationMainById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationMainController : ControllerBase
{
    private readonly ISender _sender;

    public NotificationMainController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-notificationmain")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse notificationMainList = await _sender.Send(new GetAllNotificationMainQuery());
        return Ok(notificationMainList);
    }

    [HttpGet("byid-notificationmain")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetNotificationMainByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-notificationmain")]
    public async Task<IActionResult> CreateAsync(CreateNotificationMainRequest notificationMain)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpPut("update-notificationmain")]
    public async Task<IActionResult> UpdateAsync(UpdateNotificationMainRequest notificationMain)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpDelete("delete-notificationmain")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteNotificationMainCommand(Id));
        return Ok(result);
    }
}