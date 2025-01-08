#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.DeleteTimeLog;
public record DeleteTimeLogCommand(Guid Id) : IRequest<ServerResponse>;