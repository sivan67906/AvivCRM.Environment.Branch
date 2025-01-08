#region

using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;
public record CreateTimeLogCommand(CreateTimeLogRequest TimeLog) : IRequest<ServerResponse>;