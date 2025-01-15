#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Query.GetProjectStatusById;
public record GetProjectStatusByIdQuery(Guid Id) : IRequest<ServerResponse>;