#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Query.GetAllJobApplicationPosition;
public record GetAllJobApplicationPositionQuery : IRequest<ServerResponse>;