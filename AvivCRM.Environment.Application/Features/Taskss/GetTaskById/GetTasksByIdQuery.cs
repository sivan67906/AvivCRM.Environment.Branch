using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.GetTaskById;
public record GetTasksByIdQuery(Guid Id) : IRequest<ServerResponse>;
