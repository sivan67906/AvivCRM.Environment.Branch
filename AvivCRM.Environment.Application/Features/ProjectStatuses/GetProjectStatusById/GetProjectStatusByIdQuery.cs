#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.GetProjectStatusById;
public record GetProjectStatusByIdQuery(Guid Id) : IRequest<ServerResponse>;