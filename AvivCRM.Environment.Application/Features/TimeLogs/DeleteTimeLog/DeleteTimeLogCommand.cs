using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeLogs.DeleteTimeLog;
public record DeleteTimeLogCommand(Guid Id) : IRequest<ServerResponse>;









