#region

using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Application.Features.AttendanceSettings.Command.CreateAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.Command.DeleteAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.Command.UpdateAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.Query.GetAllAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.Query.GetAttendanceSettingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AvivCRM.Environment.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AttendanceSettingController : ControllerBase
{
    private readonly ISender _sender;

    public AttendanceSettingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("all-attendancesetting")]
    public async Task<IActionResult> GetAllAsync()
    {
        Domain.Responses.ServerResponse attendancesettingList = await _sender.Send(new GetAllAttendanceSettingQuery());
        return Ok(attendancesettingList);
    }

    [HttpGet("byid-attendancesetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new GetAttendanceSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-attendancesetting")]
    public async Task<IActionResult> CreateAsync(CreateAttendanceSettingRequest attendancesetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new CreateAttendanceSettingCommand(attendancesetting));
        return Ok(result);
    }

    [HttpPut("update-attendancesetting")]
    public async Task<IActionResult> UpdateAsync(UpdateAttendanceSettingRequest attendancesetting)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new UpdateAttendanceSettingCommand(attendancesetting));
        return Ok(result);
    }

    [HttpDelete("delete-attendancesetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        Domain.Responses.ServerResponse result = await _sender.Send(new DeleteAttendanceSettingCommand(Id));
        return Ok(result);
    }
}