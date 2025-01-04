using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.DeleteProjectStatus;
public record DeleteProjectStatusCommand(Guid Id) : IRequest<ServerResponse>;









