using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeLogs.UpdateTimeLog;

public record UpdateTimeLogCommand(UpdateTimeLogRequest TimeLog) : IRequest<ServerResponse>;









