using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.GetProjectStatusById;

public record GetProjectStatusByIdQuery(Guid Id) : IRequest<ServerResponse>;









