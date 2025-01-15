#region

using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.CreateJobApplicationPosition;
public record CreateJobApplicationPositionCommand(CreateJobApplicationPositionRequest JobApplicationPosition)
    : IRequest<ServerResponse>;