using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.AttendanceSettings.GetAllAttendanceSetting;
public record GetAllAttendanceSettingQuery : IRequest<ServerResponse>;
