#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.Query.GetAttendanceSettingById;
public record GetAttendanceSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;