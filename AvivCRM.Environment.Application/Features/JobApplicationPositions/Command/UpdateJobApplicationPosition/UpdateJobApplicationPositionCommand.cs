#region

using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.UpdateJobApplicationPosition;
public record UpdateJobApplicationPositionCommand(UpdateJobApplicationPositionRequest JobApplicationPosition)
    : IRequest<ServerResponse>;