using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.UpdateJobApplicationPosition;

public record UpdateJobApplicationPositionCommand(UpdateJobApplicationPositionRequest JobApplicationPosition) : IRequest<ServerResponse>;

















