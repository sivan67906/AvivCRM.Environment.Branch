using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.DeleteAttendanceSetting;
public record DeleteAttendanceSettingCommand(Guid Id) : IRequest<ServerResponse>;
