using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.GetPlanningById;
public record GetPlanningByIdQuery(Guid Id) : IRequest<ServerResponse>;
