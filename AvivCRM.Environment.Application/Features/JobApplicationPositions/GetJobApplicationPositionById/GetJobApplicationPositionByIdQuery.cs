using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.GetJobApplicationPositionById;

public record GetJobApplicationPositionByIdQuery(Guid Id) : IRequest<ServerResponse>;

















