#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Query.GetAllTimeLog;
public record GetAllTimeLogQuery : IRequest<ServerResponse>;