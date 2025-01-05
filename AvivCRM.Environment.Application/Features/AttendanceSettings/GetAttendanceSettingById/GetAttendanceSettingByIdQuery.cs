using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.GetAttendanceSettingById;
public record GetAttendanceSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;