using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.DeleteJobApplicationPosition;
public record DeleteJobApplicationPositionCommand(Guid Id) : IRequest<ServerResponse>;

















