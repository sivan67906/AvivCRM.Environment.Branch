#region

using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.CreateAttendanceSetting;
public record CreateAttendanceSettingCommand(CreateAttendanceSettingRequest AttendanceSetting)
    : IRequest<ServerResponse>;