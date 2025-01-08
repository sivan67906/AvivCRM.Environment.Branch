#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.DeleteJobApplicationPosition;
public record DeleteJobApplicationPositionCommand(Guid Id) : IRequest<ServerResponse>;