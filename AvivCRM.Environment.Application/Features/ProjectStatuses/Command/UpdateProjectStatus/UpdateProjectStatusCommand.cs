#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Command.UpdateProjectStatus;
public record UpdateProjectStatusCommand(UpdateProjectStatusRequest ProjectStatus) : IRequest<ServerResponse>;