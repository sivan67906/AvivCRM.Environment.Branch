#region

using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Command.UpdateTimeLog;
public record UpdateTimeLogCommand(UpdateTimeLogRequest TimeLog) : IRequest<ServerResponse>;