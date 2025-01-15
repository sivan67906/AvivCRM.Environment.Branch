#region

using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.Command.CreateAttendanceSetting;
public record CreateAttendanceSettingCommand(CreateAttendanceSettingRequest AttendanceSetting)
    : IRequest<ServerResponse>;