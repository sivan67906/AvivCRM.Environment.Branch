using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.CreateProjectStatus;

public record CreateProjectStatusCommand(CreateProjectStatusRequest ProjectStatus) : IRequest<ServerResponse>;









