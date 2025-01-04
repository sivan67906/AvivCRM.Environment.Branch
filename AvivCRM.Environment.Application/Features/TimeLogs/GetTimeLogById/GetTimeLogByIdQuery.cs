using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TimeLogs.GetTimeLogById;

public record GetTimeLogByIdQuery(Guid Id) : IRequest<ServerResponse>;









