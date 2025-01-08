#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.GetAllAttendanceSetting;
public record GetAllAttendanceSettingQuery : IRequest<ServerResponse>;