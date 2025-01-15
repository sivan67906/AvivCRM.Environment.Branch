#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Query.GetAllProjectStatus;
public record GetAllProjectStatusQuery : IRequest<ServerResponse>;