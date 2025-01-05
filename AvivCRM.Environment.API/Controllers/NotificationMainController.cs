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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _sender.Send(new GetNotificationMainByIdQuery(Id));
        return Ok(result);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateNotificationMainRequest notificationMain)
    {
        var result = await _sender.Send(new CreateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateNotificationMainRequest notificationMain)
    {
        var result = await _sender.Send(new UpdateNotificationMainCommand(notificationMain));
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var notificationMainList = await _sender.Send(new GetAllNotificationMainQuery());
        return Ok(notificationMainList);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _sender.Send(new DeleteNotificationMainCommand(Id));
        return Ok(result);
    }
}









