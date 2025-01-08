#region

using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.CreateJobApplicationPosition;
public record CreateJobApplicationPositionCommand(CreateJobApplicationPositionRequest JobApplicationPosition)
    : IRequest<ServerResponse>;