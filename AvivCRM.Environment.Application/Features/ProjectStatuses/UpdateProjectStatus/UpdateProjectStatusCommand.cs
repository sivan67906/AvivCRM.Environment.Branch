#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.UpdateProjectStatus;
public record UpdateProjectStatusCommand(UpdateProjectStatusRequest ProjectStatus) : IRequest<ServerResponse>;