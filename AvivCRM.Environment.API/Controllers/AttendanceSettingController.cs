#region

using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Application.Features.AttendanceSettings.CreateAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.DeleteAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.GetAllAttendanceSetting;
using AvivCRM.Environment.Application.Features.AttendanceSettings.GetAttendanceSettingById;
using AvivCRM.Environment.Application.Features.AttendanceSettings.UpdateAttendanceSetting;
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
        var attendancesettingList = await _sender.Send(new GetAllAttendanceSettingQuery());
        return Ok(attendancesettingList);
    }

    [HttpGet("byid-attendancesetting")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _sender.Send(new GetAttendanceSettingByIdQuery(Id));
        return Ok(result);
    }

    [HttpPost("create-attendancesetting")]
    public async Task<IActionResult> CreateAsync(CreateAttendanceSettingRequest attendancesetting)
    {
        var result = await _sender.Send(new CreateAttendanceSettingCommand(attendancesetting));
        return Ok(result);
    }

    [HttpPut("update-attendancesetting")]
    public async Task<IActionResult> UpdateAsync(UpdateAttendanceSettingRequest attendancesetting)
    {
        var result = await _sender.Send(new UpdateAttendanceSettingCommand(attendancesetting));
        return Ok(result);
    }

    [HttpDelete("delete-attendancesetting")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        var result = await _sender.Send(new DeleteAttendanceSettingCommand(Id));
        return Ok(result);
    }
}