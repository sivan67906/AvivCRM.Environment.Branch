#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Query.GetJobApplicationPositionById;
public record GetJobApplicationPositionByIdQuery(Guid Id) : IRequest<ServerResponse>;