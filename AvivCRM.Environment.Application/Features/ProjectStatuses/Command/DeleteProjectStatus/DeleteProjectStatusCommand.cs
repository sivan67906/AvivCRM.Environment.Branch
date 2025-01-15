#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Command.DeleteProjectStatus;
public record DeleteProjectStatusCommand(Guid Id) : IRequest<ServerResponse>;