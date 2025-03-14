#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Command.CreateProjectStatus;
public record CreateProjectStatusCommand(CreateProjectStatusRequest ProjectStatus) : IRequest<ServerResponse>;