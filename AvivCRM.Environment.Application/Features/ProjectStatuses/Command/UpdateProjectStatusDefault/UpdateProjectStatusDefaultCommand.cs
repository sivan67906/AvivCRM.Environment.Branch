#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Command.UpdateProjectStatusDefault;
public record UpdateProjectStatusDefaultCommand(UpdateProjectStatusDefaultRequest ProjectStatus)
    : IRequest<ServerResponse>;