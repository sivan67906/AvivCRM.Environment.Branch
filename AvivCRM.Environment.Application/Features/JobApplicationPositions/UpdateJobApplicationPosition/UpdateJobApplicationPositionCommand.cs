#region

using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.UpdateJobApplicationPosition;
public record UpdateJobApplicationPositionCommand(UpdateJobApplicationPositionRequest JobApplicationPosition)
    : IRequest<ServerResponse>;