#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.DeleteAttendanceSetting;
public record DeleteAttendanceSettingCommand(Guid Id) : IRequest<ServerResponse>;