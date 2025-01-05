using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Application.Features.NotificationMains.CreateNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.DeleteNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.GetAllNotificationMain;
using AvivCRM.Environment.Application.Features.NotificationMains.GetNotificationMainById;
using AvivCRM.Environment.Application.Features.NotificationMains.UpdateNotificationMain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvivCRM.Environment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationMainController : ControllerBase
{

    private readonly ISender _sender;
    public NotificationMainController(ISender sender) => _sender = sender;

    [HttpGet("byid")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetNotificationMainByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateNotificationMainRequest notificationMain)
    {
        var result = await _sender.Send(new CreateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateNotificationMainRequest notificationMain)
    {
        var result = await _sender.Send(new UpdateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var notificationMainList = await _sender.Send(new GetAllNotificationMainQuery());
        return Ok(notificationMainList);
    }


    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteNotificationMainCommand(Id));
        return Ok(result);
    }
}

