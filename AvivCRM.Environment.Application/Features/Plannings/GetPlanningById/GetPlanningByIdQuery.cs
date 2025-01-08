#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.GetPlanningById;
public record GetPlanningByIdQuery(Guid Id) : IRequest<ServerResponse>;