#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.Query.GetTimeLogById;
public record GetTimeLogByIdQuery(Guid Id) : IRequest<ServerResponse>;