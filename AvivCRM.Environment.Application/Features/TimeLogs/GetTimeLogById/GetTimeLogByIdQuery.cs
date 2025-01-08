#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.GetTimeLogById;
public record GetTimeLogByIdQuery(Guid Id) : IRequest<ServerResponse>;